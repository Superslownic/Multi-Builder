using Editor.Sources.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Editor.Sources.Instructions
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