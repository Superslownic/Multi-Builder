using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Multi.Builder.Constants.Categories;

namespace Multi.Builder.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + Android + "Architecture"), InlineEditor]
    public class AndroidArchitecture : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel, EnumToggleButtons] private UnityEditor.AndroidArchitecture _architecture;
        
        public void Process(BuildSettings settings)
        {
            PlayerSettings.Android.targetArchitectures = _architecture;
        }
    }
}