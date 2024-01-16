using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder
{
  public class MultiBuilder : OdinEditorWindow
  {
    [MenuItem("Tools/Multi Builder")]
    private static void OpenWindow()
    {
      GetWindow<MultiBuilder>().Show();
    }

    [Title("Profile")] [ShowInInspector, HideLabel]
    private BuildProfile _profile;

    [PropertySpace]
    [Button, ShowIf(nameof(_profile))]
    public void Build()
    {
      var settings = RunInstructions();
      BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, settings.FullPath, settings.BuildTarget, settings.BuildOptions);
    }

    [Button, ShowIf(nameof(_profile))]
    public void BuildAndRun()
    {
      var settings = RunInstructions();
      settings.BuildOptions |= BuildOptions.AutoRunPlayer;
      BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, settings.FullPath, settings.BuildTarget, settings.BuildOptions);
    }

    private BuildSettings RunInstructions()
    {
      BuildSettings settings = new BuildSettings();

      List<IBuildInstruction> instructions = new List<IBuildInstruction>(_profile.Instructions);
      
      foreach (IBuildInstruction instruction in _profile.Instructions)
      {
        if (instruction.Dependencies.Length <= 0)
          continue;
        
        int currentIndex = instructions.FindIndex(x => x == instruction);

        foreach (Type dependency in instruction.Dependencies)
        {
          int index = instructions.FindIndex(x => x.GetType() == dependency);

          if(index < currentIndex)
            continue;
          
          bool lastElement = index == instructions.Count - 1;
          instructions.Remove(instruction);

          if(lastElement)
          {
            instructions.Add(instruction);
          }
          else
          {
            instructions.Insert(index, instruction);
          }
        }
      }

      foreach (IBuildInstruction instruction in _profile.Instructions)
        instruction.Process(settings);

      return settings;
    }
  }
}