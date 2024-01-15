using System.Collections.Generic;
using System.IO;
using System.Linq;
using Multi_Builder.Editor.Utilities;
using Multi.Builder.Constants;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
	public class AndroidKeystoreDrawer : OdinValueDrawer<AndroidKeystore>
	{
		private string[] _aliases;
    
		protected override void Initialize()
		{
			UpdateKeystoreAliases();
		}

		protected override void DrawPropertyLayout(GUIContent label)
		{
			ValueEntry.SmartValue.UseCustomKeystore =
				EditorGUILayout.ToggleLeft("Use Custom Keystore", ValueEntry.SmartValue.UseCustomKeystore);

			if (ValueEntry.SmartValue.UseCustomKeystore)
			{
				bool keystorePathChanged = DrawKeystorePathSelector();

				if (keystorePathChanged)
				{
					ValueEntry.SmartValue.LoadKeystoreMeta();
					UpdateKeystoreAliases();
				}

				if (IsKeystoreFileExists())
				{
					bool keystorePasswordChanged = DrawKeystorePasswordSelector();

					if (keystorePasswordChanged)
					{
						UpdateKeystoreAliases();
					}

					DrawAliasSelector();
					DrawAliasPasswordSelector();
				}
			}

			if (GUI.changed)
			{
				ValueEntry.ApplyChanges();
				ValueEntry.SmartValue.SaveKeystoreMeta();
			}
		}

		private void UpdateKeystoreAliases()
		{
			if(IsKeystoreFileExists())
			{
				_aliases = KeystoreExtensions
					.GetAliases(ValueEntry.SmartValue.KeystorePath, ValueEntry.SmartValue.KeystoreMeta.KeystorePassword)
					.ToArray();
			}
		}

		private bool IsKeystoreFileExists()
		{
			return !string.IsNullOrEmpty(ValueEntry.SmartValue.KeystorePath)
			       && File.Exists(ValueEntry.SmartValue.KeystorePath);
		}

		private bool DrawKeystorePathSelector()
		{
			string lastPath = ValueEntry.SmartValue.KeystorePath;
			ValueEntry.SmartValue.KeystorePath =
				SirenixEditorFields.FilePathField(new GUIContent("Keystore Path"),
					ValueEntry.SmartValue.KeystorePath, null, Extensions.KEYSTORE, true, false);
			return lastPath != ValueEntry.SmartValue.KeystorePath;
		}

		private bool DrawKeystorePasswordSelector()
		{
			string lastPassword = ValueEntry.SmartValue.KeystoreMeta.KeystorePassword;
			ValueEntry.SmartValue.KeystoreMeta.KeystorePassword =
				SirenixEditorFields.TextField("Keystore Password", ValueEntry.SmartValue.KeystoreMeta.KeystorePassword);
			return lastPassword != ValueEntry.SmartValue.KeystoreMeta.KeystorePassword;
		}

		private void DrawAliasSelector()
		{
			if (_aliases == null || _aliases.Length == 0)
				return;

			ValueEntry.SmartValue.Alias =
				SirenixEditorFields.Dropdown(new GUIContent("Alias"), ValueEntry.SmartValue.Alias, _aliases);
		}
    
		private void DrawAliasPasswordSelector()
		{
			if (string.IsNullOrEmpty(ValueEntry.SmartValue.Alias))
				return;

			string password =
				ValueEntry.SmartValue.KeystoreMeta.AliasPassword.GetValueOrDefault(ValueEntry.SmartValue.Alias, "");

			ValueEntry.SmartValue.KeystoreMeta.AliasPassword[ValueEntry.SmartValue.Alias] =
				SirenixEditorFields.TextField(new GUIContent("Alias Password"), password);
		}
	}
}