using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Multi.Builder.Constants.Categories;

namespace Multi.Builder.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + Android + "Icon"), InlineEditor]
    public class AndroidIcon : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel] private Texture2D _icon;
        
        public void Process(BuildSettings settings)
        {
            PlayerSettings.SetIconsForTargetGroup(settings.BuildTargetGroup, new []
            {
                _icon,
                _icon,
                _icon,
                _icon,
                _icon,
                _icon
            });
        }
    }
}