using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder
{
  [CreateAssetMenu(menuName = "Multi Builder/Profile"), InlineEditor]
  public class BuildProfile : SerializedScriptableObject
  {
    public readonly IBuildInstruction[] Instructions = new IBuildInstruction[0];
  }
}