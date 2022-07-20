using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Multi.Builder.Constants.Categories;
using static Multi.Builder.Constants.Extensions;

namespace Multi.Builder.Instructions
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