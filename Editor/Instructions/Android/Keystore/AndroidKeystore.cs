using System;
using System.IO;
using Multi.Builder.Constants;
using Newtonsoft.Json;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class AndroidKeystore : IPreBuildInstructionSync
  {
    [SerializeField] public bool UseCustomKeystore;
    [SerializeField] public string KeystorePath;
    [SerializeField] public string Alias;

    private KeystoreMeta _keystoreMeta;

    private string KeystoreMetaPath => $"{KeystorePath}{Extensions.META}";

    public KeystoreMeta KeystoreMeta
    {
      get
      {
        if (_keystoreMeta == null)
        {
          LoadKeystoreMeta();
        }

        return _keystoreMeta;
      }
    }

    public void Process(BuildSettings settings)
    {
      PlayerSettings.Android.useCustomKeystore = UseCustomKeystore;

      if (!UseCustomKeystore)
        return;

      PlayerSettings.Android.keystoreName = KeystorePath;
      PlayerSettings.Android.keystorePass = KeystoreMeta.KeystorePassword;
      PlayerSettings.Android.keyaliasName = Alias;
      PlayerSettings.Android.keyaliasPass = KeystoreMeta.AliasPassword[Alias];
    }

    public void LoadKeystoreMeta()
    {
      if (!IsKeystoreFileExists())
        return;

      if(!IsKeystoreMetaFileExists())
      {
        CreateKeystoreMeta();
        return;
      }

      string json = File.ReadAllText(KeystoreMetaPath);
      _keystoreMeta = JsonConvert.DeserializeObject<KeystoreMeta>(json);
    }

    public void SaveKeystoreMeta()
    {
      string json = JsonConvert.SerializeObject(_keystoreMeta, typeof(KeystoreMeta), Formatting.Indented, null);
      File.WriteAllText(KeystoreMetaPath, json);
    }

    private bool IsKeystoreFileExists()
    {
      return !string.IsNullOrEmpty(KeystorePath) && File.Exists(KeystorePath);
    }

    private bool IsKeystoreMetaFileExists()
    {
      return File.Exists(KeystoreMetaPath);
    }

    private void CreateKeystoreMeta()
    {
      if (IsKeystoreMetaFileExists())
        return;

      _keystoreMeta = new KeystoreMeta();
      SaveKeystoreMeta();
    }
  }
}