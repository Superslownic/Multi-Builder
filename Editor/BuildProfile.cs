using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder
{
  [CreateAssetMenu(menuName = "Multi Builder/Profile"), InlineEditor]
  public class BuildProfile : ScriptableObject
  {
    [field: SerializeReference] public IBuildInstruction[] Instructions { get; private set; }
  }
}