using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class APICompatibilityLevel : IBuildInstruction
  {
    [SerializeField, HideLabel, EnumToggleButtons]
    private ApiCompatibilityLevel _level;

    public Type[] Dependencies { get; private set; } =
    {
      typeof(BuildTarget)
    };

    public void Process(BuildSettings settings)
    {
      PlayerSettings.SetApiCompatibilityLevel(settings.BuildTargetGroup, _level);
    }
  }
}