using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(BuildLocation)), InlineEditor]
    public class BuildLocation : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel, FolderPath(AbsolutePath = true)] private string _path;
        
        public void Process(BuildSettings settings)
        {
            settings.Path = _path;
        }
    }
}