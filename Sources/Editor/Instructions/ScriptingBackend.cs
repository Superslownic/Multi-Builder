﻿using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(ScriptingBackend)), InlineEditor]
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