using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Editor.Sources.Constants.Categories;

namespace Editor.Sources.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + Android + "API Level"), InlineEditor]
    public class AndroidAPILevel : ScriptableObject, IBuildInstruction
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