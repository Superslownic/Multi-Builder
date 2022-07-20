using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using FilePath = Sirenix.OdinInspector.FilePathAttribute;
using static Multi.Builder.Constants.Categories;
using static Multi.Builder.Constants.Extensions;

namespace Multi.Builder.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + Android + "Keystore"), InlineEditor]
    public class AndroidKeystore : ScriptableObject, IBuildInstruction
    {
        [SerializeField, ToggleLeft] private bool _useCustomKeystore;
        [SerializeField, ShowIf(nameof(_useCustomKeystore)), FilePath(Extensions = Keystore, AbsolutePath = true)] private string _file;
        [SerializeField, ShowIf(nameof(_useCustomKeystore))] private string _password;
        [SerializeField, ShowIf(nameof(_useCustomKeystore))] private string _alias;
        [SerializeField, ShowIf(nameof(_useCustomKeystore))] private string _aliasPassword;
        
        public void Process(BuildSettings settings)
        {
            PlayerSettings.Android.useCustomKeystore = _useCustomKeystore;
            
            if(!_useCustomKeystore)
                return;
            
            PlayerSettings.Android.keystoreName = _file;
            PlayerSettings.Android.keystorePass = _password;
            PlayerSettings.Android.keyaliasName = _alias;
            PlayerSettings.Android.keyaliasPass = _aliasPassword;
        }
    }
}