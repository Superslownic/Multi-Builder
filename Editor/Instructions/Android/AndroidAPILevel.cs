using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class AndroidAPILevel : IBuildInstruction
  {
    [SerializeField, EnumPaging] private AndroidSdkVersions _minimum;
    [SerializeField, EnumPaging] private AndroidSdkVersions _target;

    public void Process(BuildSettings settings)
    {
      PlayerSettings.Android.minSdkVersion = _minimum;
      PlayerSettings.Android.targetSdkVersion = _target;
    }
  }
}