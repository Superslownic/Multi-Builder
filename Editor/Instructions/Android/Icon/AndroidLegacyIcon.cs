using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.Android;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class AndroidLegacyIcon : IBuildInstruction
  {
    [ToggleLeft]
    public bool Extended;

    [LabelText("xxxhdpi (192x192px)")]
    public Texture2D S192;

    [LabelText("xxhdpi (144x144px)"), ShowIf(nameof(Extended))]
    public Texture2D S144;

    [LabelText("xhdpi (96x96px)"), ShowIf(nameof(Extended))]
    public Texture2D S96;

    [LabelText("hdpi (72x72px)"), ShowIf(nameof(Extended))]
    public Texture2D S72;

    [LabelText("mdpi (48x48px)"), ShowIf(nameof(Extended))]
    public Texture2D S48;

    [LabelText("ldpi (36x36px)"), ShowIf(nameof(Extended))]
    public Texture2D S36;

    public void Process(BuildSettings settings)
    {
      PlatformIcon[] platformIcons = PlayerSettings.GetPlatformIcons(BuildTargetGroup.Android, AndroidPlatformIconKind.Legacy);
      platformIcons[0].SetTextures(S192);
      platformIcons[1].SetTextures(Extended ? S144 : null);
      platformIcons[2].SetTextures(Extended ? S96 : null);
      platformIcons[3].SetTextures(Extended ? S72 : null);
      platformIcons[4].SetTextures(Extended ? S48 : null);
      platformIcons[5].SetTextures(Extended ? S36 : null);
      PlayerSettings.SetPlatformIcons(BuildTargetGroup.Android, AndroidPlatformIconKind.Legacy, platformIcons);
    }
  }
}