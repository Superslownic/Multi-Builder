using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class ScriptingBackend : IBuildInstruction
  {
    [SerializeField, HideLabel, EnumToggleButtons]
    private Backend _backend;

    public Type[] Dependencies { get; private set; } =
    {
      typeof(BuildTarget)
    };

    public void Process(BuildSettings settings)
    {
      switch (_backend)
      {
        case Backend.Mono:
          PlayerSettings.SetScriptingBackend(settings.BuildTargetGroup, ScriptingImplementation.Mono2x);
          break;
        
        case Backend.IL2CPP:
          PlayerSettings.SetScriptingBackend(settings.BuildTargetGroup, ScriptingImplementation.IL2CPP);
          break;
        
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private enum Backend
    {
      Mono,
      IL2CPP
    }
  }
}