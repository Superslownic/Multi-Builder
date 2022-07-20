using Sirenix.OdinInspector;
using UnityEngine;

namespace Editor.Sources
{
    [CreateAssetMenu, InlineEditor]
    public class BuildProfile : SerializedScriptableObject
    {
        public IBuildInstruction[] Instructions;
    }
}