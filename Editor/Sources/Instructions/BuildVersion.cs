using Editor.Sources.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Editor.Sources.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(BuildVersion)), InlineEditor]
    public class BuildVersion : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HorizontalGroup("Version",0, 0, 5), LabelText("v."), LabelWidth(15)] private string _version;
        [SerializeField, HorizontalGroup("Version"), LabelText("code"), LabelWidth(35), Min(1)] private int _versionCode;
        [SerializeField, LabelText("Bundle"), LabelWidth(45)] private string _bundleIdentifier;
        
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