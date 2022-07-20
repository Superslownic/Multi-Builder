using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Editor.Sources.Constants.Categories;
using static Editor.Sources.Constants.Extensions;

namespace Editor.Sources.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + Android + "Build Type"), InlineEditor]
    public class AndroidBuildType : ScriptableObject, IBuildInstruction
    {
        [SerializeField, EnumToggleButtons, HideLabel] private Type _type;
        
        public void Process(BuildSettings settings)
        {
            switch (_type)
            {
                case Type.APK:
                    EditorUserBuildSettings.buildAppBundle = false;
                    settings.Extension = APK;
                    break;
                case Type.AAB:
                    EditorUserBuildSettings.buildAppBundle = true;
                    settings.Extension = AAB;
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