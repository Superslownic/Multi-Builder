using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Multi.Builder.Constants.Categories;

namespace Multi.Builder.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + "Build Target"), InlineEditor]
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