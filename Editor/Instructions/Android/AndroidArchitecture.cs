using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class AndroidArchitecture : IPreBuildInstructionSync
  {
    [SerializeField, HideLabel, EnumToggleButtons]
    private UnityEditor.AndroidArchitecture _architecture;

    public void Process(BuildSettings settings)
    {
      PlayerSettings.Android.targetArchitectures = _architecture;
    }
  }
}