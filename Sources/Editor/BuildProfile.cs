using Sirenix.OdinInspector;
using UnityEngine;

namespace MultiBuilder.Sources.Editor
{
    [CreateAssetMenu, InlineEditor]
    public class BuildProfile : SerializedScriptableObject
    {
        public IBuildInstruction[] Instructions;
    }
}