using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(AndroidArchitecture)), InlineEditor]
    public class AndroidArchitecture : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel, EnumToggleButtons] private UnityEditor.AndroidArchitecture _architecture;
        
        public void Process(BuildSettings settings)
        {
            PlayerSettings.Android.targetArchitectures = _architecture;
        }
    }
}