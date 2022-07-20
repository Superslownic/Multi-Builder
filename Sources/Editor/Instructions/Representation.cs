using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(Representation)), InlineEditor]
    public class Representation : ScriptableObject, IBuildInstruction
    {
        [SerializeField] private UIOrientation _orientation;
        [SerializeField, ShowIf(nameof(_orientation), UIOrientation.AutoRotation)] private AutoOrientations _allowedOrientations;
        
        public void Process(BuildSettings settings)
        {
            PlayerSettings.defaultInterfaceOrientation = _orientation;
            PlayerSettings.allowedAutorotateToPortrait = _allowedOrientations.HasFlag(AutoOrientations.Portrait);
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = _allowedOrientations.HasFlag(AutoOrientations.PortraitUpsideDown);
            PlayerSettings.allowedAutorotateToLandscapeLeft = _allowedOrientations.HasFlag(AutoOrientations.LandscapeLeft);
            PlayerSettings.allowedAutorotateToLandscapeRight = _allowedOrientations.HasFlag(AutoOrientations.LandscapeRight);
        }
    }
}