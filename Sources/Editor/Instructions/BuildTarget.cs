﻿using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(BuildTarget)), InlineEditor]
    public class BuildTarget : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel, HorizontalGroup] private UnityEditor.BuildTarget _buildTarget;
        [SerializeField, HideLabel, HorizontalGroup] private BuildTargetGroup _buildTargetGroup;
        
        public void Process(BuildSettings settings)
        {
            settings.BuildTarget = _buildTarget;
            settings.BuildTargetGroup = _buildTargetGroup;
        }
    }
}