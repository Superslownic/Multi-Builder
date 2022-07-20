using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Editor.Sources.Constants.Categories;

namespace Editor.Sources.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + "Scripting Backend"), InlineEditor]
    public class ScriptingBackend : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel, EnumToggleButtons] private Backend _backend;
        
        public void Process(BuildSettings settings)
        {
            switch (_backend)
            {
                case Backend.Mono:
                    PlayerSettings.SetScriptingBackend(settings.BuildTargetGroup, ScriptingImplementation.Mono2x);
                    break;
                case Backend.IL2CPP:
                    PlayerSettings.SetScriptingBackend(settings.BuildTargetGroup, ScriptingImplementation.IL2CPP);
                    break;
            }
        }

        private enum Backend
        {
            Mono,
            IL2CPP
        }
    }
}