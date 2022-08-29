using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class BuildTarget : IBuildInstruction
  {
    [SerializeField, HideLabel, HorizontalGroup]
    private UnityEditor.BuildTarget _buildTarget;

    [SerializeField, HideLabel, HorizontalGroup]
    private BuildTargetGroup _buildTargetGroup;

    public void Process(BuildSettings settings)
    {
      settings.BuildTarget = _buildTarget;
      settings.BuildTargetGroup = _buildTargetGroup;
    }
  }
}