using Editor.Sources.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Editor.Sources.Instructions
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