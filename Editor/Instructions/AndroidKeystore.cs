using System;
using Multi.Builder.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using FilePath = Sirenix.OdinInspector.FilePathAttribute;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class AndroidKeystore : IBuildInstruction
  {
    [SerializeField, ToggleLeft] private bool _useCustomKeystore;

    [SerializeField, ShowIf(nameof(_useCustomKeystore)), FilePath(Extensions = Extensions.Keystore, AbsolutePath = true)]
    private string _file;

    [SerializeField, ShowIf(nameof(_useCustomKeystore))]
    private string _password;

    [SerializeField, ShowIf(nameof(_useCustomKeystore))]
    private string _alias;

    [SerializeField, ShowIf(nameof(_useCustomKeystore))]
    private string _aliasPassword;

    public void Process(BuildSettings settings)
    {
      PlayerSettings.Android.useCustomKeystore = _useCustomKeystore;

      if (!_useCustomKeystore)
        return;

      PlayerSettings.Android.keystoreName = _file;
      PlayerSettings.Android.keystorePass = _password;
      PlayerSettings.Android.keyaliasName = _alias;
      PlayerSettings.Android.keyaliasPass = _aliasPassword;
    }
  }
}