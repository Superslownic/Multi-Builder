using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
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

    private BuildProfile _profile;
    private OdinEditor _profileInstructionsEditor;
    private ProgressBarConfig _progressConfig;
    private int _currentInstructionIndex;
    private bool _inProgress;
    private string _progressText = "Instructions Progress";
    private float _progressValue;

    protected override void Initialize()
    {
      _progressConfig = new ProgressBarConfig(20, new Color(0.7f, 0.7f, 0.7f),
        ProgressBarConfig.Default.BackgroundColor, false, TextAlignment.Center);
    }

    protected override void OnGUI()
    {
      GUILayout.Space(5);
  
      _profile = (BuildProfile)SirenixEditorFields.UnityObjectField(_profile, typeof(BuildProfile), false);
      
      GUILayout.Space(5);

      if(_profile != null)
      {
        OdinEditor.ForceHideMonoScriptInEditor = true;
        GUIHelper.PushGUIPositionOffset(new Vector2(2, 0));
        if (_profileInstructionsEditor == null)
        {
          _profileInstructionsEditor = (OdinEditor)Editor.CreateEditor(_profile, typeof(OdinEditor));
        }
        _profileInstructionsEditor.OnInspectorGUI();
        GUIHelper.PopGUIPositionOffset();
        OdinEditor.ForceHideMonoScriptInEditor = false;

        GUILayout.BeginHorizontal();
        {
          Rect rect = EditorGUILayout.GetControlRect();
          rect.y += 1;
          SirenixEditorFields.ProgressBarField(rect, GUIContent.none, _progressValue, 0d, 1d, _progressConfig);
          SirenixEditorFields.ProgressBarOverlayLabel(rect, new GUIContent(_progressText), _progressValue, _progressConfig);

          if (GUILayout.Button("Build", GUILayout.Width(60)))
          {
            Build();
          }

          if (GUILayout.Button("Build And Run", GUILayout.Width(100)))
          {
            BuildAndRun();
          }
        }
        GUILayout.EndHorizontal();
      }
    }
    
    private async void Build()
    {
      BuildSettings settings = await RunInstructions();
      BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, settings.FullPath, settings.BuildTarget, settings.BuildOptions);
      _progressText = "Instructions Complete";
      Repaint();
    }

    private async void BuildAndRun()
    {
      BuildSettings settings = await RunInstructions();
      settings.BuildOptions |= BuildOptions.AutoRunPlayer;
      BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, settings.FullPath, settings.BuildTarget, settings.BuildOptions);
      _progressText = "Instructions Complete";
      Repaint();
    }

    private async Task<BuildSettings> RunInstructions()
    {
      _inProgress = true;
      _progressValue = 0;
      BuildSettings settings = new BuildSettings();

      List<IPreBuildInstruction> instructions = new List<IPreBuildInstruction>(_profile.Instructions);
      
      foreach (IPreBuildInstruction instruction in _profile.Instructions)
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

      for (var i = 0; i < _profile.Instructions.Count; i++)
      {
        _progressText = $"Executing {_profile.Instructions[i].GetType().GetNiceName()}";
        _currentInstructionIndex = i;

        switch (_profile.Instructions[i])
        {
          case IPreBuildInstructionSync instructionSync:
            instructionSync.Process(settings);
            break;

          case IPreBuildInstructionAsync instructionAsync:
            await instructionAsync.Process(settings);
            break;
        }
      }

      while (_progressValue < 1)
        await Task.Yield();

      _inProgress = false;
      return settings;
    }

    private void Update()
    {
      if (!_inProgress)
        return;

      _progressValue = Mathf.MoveTowards(_progressValue, (_currentInstructionIndex + 1) / (float)_profile.Instructions.Count, 0.05f);
      Repaint();
    }
  }
}