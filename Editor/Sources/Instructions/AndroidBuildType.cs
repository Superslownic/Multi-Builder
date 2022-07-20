using Editor.Sources.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Editor.Sources.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(AndroidBuildType)), InlineEditor]
    public class AndroidBuildType : ScriptableObject, IBuildInstruction
    {
        [SerializeField, EnumToggleButtons, HideLabel] private Type _type;
        
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
            }
        }

        private enum Type
        {
            APK,
            AAB
        }
    }
}