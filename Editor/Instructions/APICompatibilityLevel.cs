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
    private Level _level;

    public void Process(BuildSettings settings)
    {
      switch (_level)
      {
        case Level.NET_Standard_2_0:
          PlayerSettings.SetApiCompatibilityLevel(settings.BuildTargetGroup,
            ApiCompatibilityLevel.NET_Standard_2_0);
          break;
        
        case Level.NET_4_X:
          PlayerSettings.SetApiCompatibilityLevel(settings.BuildTargetGroup,
            ApiCompatibilityLevel.NET_Standard_2_0);
          break;
        
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private enum Level
    {
      NET_Standard_2_0,
      NET_4_X
    }
  }
}