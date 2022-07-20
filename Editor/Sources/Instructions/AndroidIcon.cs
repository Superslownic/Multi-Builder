using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Editor.Sources.Constants.Categories;

namespace Editor.Sources.Instructions
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