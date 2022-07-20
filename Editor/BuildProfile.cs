using Multi.Builder.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder
{
    [CreateAssetMenu(menuName = Categories.Main + Name), InlineEditor]
    public class BuildProfile : SerializedScriptableObject
    {
        public const string Name = "Profile";
        
        public IBuildInstruction[] Instructions;
    }
}