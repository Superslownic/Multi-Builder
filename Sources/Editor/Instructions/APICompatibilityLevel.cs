using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(APICompatibilityLevel)), InlineEditor]
    public class APICompatibilityLevel : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel, EnumToggleButtons] private Level _level;
        
        public void Process(BuildSettings settings)
        {
            switch (_level)
            {
                case Level.NET_Standard_2_0:
                    PlayerSettings.SetApiCompatibilityLevel(settings.BuildTargetGroup,
                        ApiCompatibilityLevel.NET_Standard_2_0);
                    break;
                case Level.NET_4_X:
                    PlayerSettings.SetApiCompatibilityLevel(settings.BuildTargetGroup,
                        ApiCompatibilityLevel.NET_Standard_2_0);
                    break;
            }
        }

        private enum Level
        {
            NET_Standard_2_0,
            NET_4_X
        }
    }
}