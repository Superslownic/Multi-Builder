using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class BuildTarget : IPreBuildInstructionSync
  {
    [SerializeField, HideLabel, HorizontalGroup]
    private UnityEditor.BuildTarget _buildTarget = UnityEditor.BuildTarget.Android;

    [SerializeField, HideLabel, HorizontalGroup]
    private BuildTargetGroup _buildTargetGroup = BuildTargetGroup.Android;

    public void Process(BuildSettings settings)
    {
      settings.BuildTarget = _buildTarget;
      settings.BuildTargetGroup = _buildTargetGroup;
    }
  }
}