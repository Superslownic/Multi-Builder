using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEditor.Android;
using UnityEngine;

namespace Multi.Builder.Instructions
{
	[Serializable, InlineEditor]
	public class AndroidAdaptiveIcon : IPreBuildInstructionSync
	{
		[ToggleLeft]
		public bool Extended;

		[FoldoutGroup("xxxhdpi (432x432px)"), LabelText("Background")]
		public Texture2D B432;

		[FoldoutGroup("xxxhdpi (432x432px)"), LabelText("Foreground")]
		public Texture2D F432;

		[FoldoutGroup("xxhdpi (324x324px)"), LabelText("Background"), ShowIf(nameof(Extended))]
		public Texture2D B324;

		[FoldoutGroup("xxhdpi (324x324px)"), LabelText("Foreground"), ShowIf(nameof(Extended))]
		public Texture2D F324;

		[FoldoutGroup("xhdpi (216x216px)"), LabelText("Background"), ShowIf(nameof(Extended))]
		public Texture2D B216;

		[FoldoutGroup("xhdpi (216x216px)"), LabelText("Foreground"), ShowIf(nameof(Extended))]
		public Texture2D F216;

		[FoldoutGroup("hdpi (162x162px)"), LabelText("Background"), ShowIf(nameof(Extended))]
		public Texture2D B162;

		[FoldoutGroup("hdpi (162x162px)"), LabelText("Foreground"), ShowIf(nameof(Extended))]
		public Texture2D F162;

		[FoldoutGroup("mdpi (108x108px)"), LabelText("Background"), ShowIf(nameof(Extended))]
		public Texture2D B108;

		[FoldoutGroup("mdpi (108x108px)"), LabelText("Foreground"), ShowIf(nameof(Extended))]
		public Texture2D F108;

		[FoldoutGroup("ldpi (81x81px)"), LabelText("Background"), ShowIf(nameof(Extended))]
		public Texture2D B81;

		[FoldoutGroup("ldpi (81x81px)"), LabelText("Foreground"), ShowIf(nameof(Extended))]
		public Texture2D F81;

		public void Process(BuildSettings settings)
		{
			PlatformIcon[] platformIcons = PlayerSettings.GetPlatformIcons(BuildTargetGroup.Android, AndroidPlatformIconKind.Adaptive);
			platformIcons[0].SetTextures(B432, F432);
			platformIcons[1].SetTextures(Extended ? new [] { B324, F324 } : Array.Empty<Texture2D>());
			platformIcons[2].SetTextures(Extended ? new [] { B216, F216 } : Array.Empty<Texture2D>());
			platformIcons[3].SetTextures(Extended ? new [] { B162, F162 } : Array.Empty<Texture2D>());
			platformIcons[4].SetTextures(Extended ? new [] { B108, F108 } : Array.Empty<Texture2D>());
			platformIcons[5].SetTextures(Extended ? new [] { B81, F81 } : Array.Empty<Texture2D>());
			PlayerSettings.SetPlatformIcons(BuildTargetGroup.Android, AndroidPlatformIconKind.Adaptive, platformIcons);
		}
	}
}