using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(AndroidAPILevel)), InlineEditor]
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