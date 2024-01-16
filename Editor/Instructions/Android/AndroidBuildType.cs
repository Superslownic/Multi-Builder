using System;
using Multi.Builder.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class AndroidBuildType : IBuildInstruction
  {
    [SerializeField, EnumToggleButtons, HideLabel]
    private Type _type;

    public void Process(BuildSettings settings)
    {
      switch (_type)
      {
        case Type.APK:
          EditorUserBuildSettings.buildAppBundle = false;
          settings.Extension = Extensions.APK;
          break;
        
        case Type.AAB:
          EditorUserBuildSettings.buildAppBundle = true;
          settings.Extension = Extensions.AAB;
          break;
        
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private enum Type
    {
      APK,
      AAB
    }
  }
}