using Editor.Sources.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Editor.Sources
{
    [CreateAssetMenu(menuName = Categories.Main + Name), InlineEditor]
    public class BuildProfile : SerializedScriptableObject
    {
        public const string Name = "Profile";
        
        public IBuildInstruction[] Instructions;
    }
}