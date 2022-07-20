using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(AndroidIcon)), InlineEditor]
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