using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class BuildVersion : IBuildInstruction
  {
    [SerializeField, HorizontalGroup("Version", 0, 0, 5), LabelText("v."), LabelWidth(15)]
    private string _version;

    [SerializeField, HorizontalGroup("Version"), LabelText("code"), LabelWidth(35), Min(1)]
    private int _versionCode;

    [SerializeField, LabelText("Bundle"), LabelWidth(45)]
    private string _bundleIdentifier;

    public void Process(BuildSettings settings)
    {
      settings.Version = _version;
      settings.VersionCode = _versionCode;
      PlayerSettings.bundleVersion = _version.Trim();
      PlayerSettings.applicationIdentifier = _bundleIdentifier.Trim();
      PlayerSettings.Android.bundleVersionCode = _versionCode;
    }
  }
}