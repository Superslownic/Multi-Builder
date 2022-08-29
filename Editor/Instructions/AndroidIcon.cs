using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class AndroidIcon : IBuildInstruction
  {
    [SerializeField, HideLabel] private Texture2D _icon;

    public void Process(BuildSettings settings)
    {
      PlayerSettings.SetIconsForTargetGroup(settings.BuildTargetGroup, new[]
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