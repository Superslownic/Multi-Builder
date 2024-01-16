using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder
{
  [CreateAssetMenu(menuName = "Multi Builder/Profile"), InlineEditor]
  public class BuildProfile : ScriptableObject
  {
    [field: SerializeReference, Searchable] public List<IPreBuildInstruction> Instructions { get; private set; }
  }
}