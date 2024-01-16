using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class Representation : IPreBuildInstructionSync
  {
    [SerializeField] private UIOrientation _orientation;

    [SerializeField, ShowIf(nameof(_orientation), UIOrientation.AutoRotation)]
    private AutoOrientations _allowedOrientations;

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