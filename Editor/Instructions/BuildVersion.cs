using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class BuildVersion : IBuildInstruction
  {
    [SerializeField]
    private string _version = "0.1";

    [SerializeField, Min(1)]
    private int _bundle = 1;

    public void Process(BuildSettings settings)
    {
      settings.Version = _version;
      settings.VersionCode = _bundle;
      PlayerSettings.bundleVersion = _version.Trim();
      PlayerSettings.Android.bundleVersionCode = _bundle;
    }
  }
}