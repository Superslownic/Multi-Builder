using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(AndroidIconSet)), InlineEditor]
    public class AndroidIconSet : ScriptableObject, IBuildInstruction
    {
        [HorizontalGroup("Split"), BoxGroup("Split/192px", centerLabel: true), HideLabel, PreviewField] public Texture2D S192;
        [HorizontalGroup("Split"), BoxGroup("Split/144px", centerLabel: true), HideLabel, PreviewField] public Texture2D S144;
        [HorizontalGroup("Split"), BoxGroup("Split/96px", centerLabel: true), HideLabel, PreviewField] public Texture2D S96;
        [HorizontalGroup("Split"), BoxGroup("Split/72px", centerLabel: true), HideLabel, PreviewField] public Texture2D S72;
        [HorizontalGroup("Split"), BoxGroup("Split/48px", centerLabel: true), HideLabel, PreviewField] public Texture2D S48;
        [HorizontalGroup("Split"), BoxGroup("Split/36px", centerLabel: true), HideLabel, PreviewField] public Texture2D S36;
        
        public void Process(BuildSettings settings)
        {
            PlayerSettings.SetIconsForTargetGroup(settings.BuildTargetGroup, new []
            {
                S192,
                S144,
                S96,
                S72,
                S48,
                S36,
            });
        }
    }
}