using Sirenix.OdinInspector;
using UnityEngine;
using static Editor.Sources.Constants.Categories;

namespace Editor.Sources.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + "Build Location"), InlineEditor]
    public class BuildLocation : ScriptableObject, IBuildInstruction
    {
        [SerializeField, HideLabel, FolderPath(AbsolutePath = true)] private string _path;
        
        public void Process(BuildSettings settings)
        {
            settings.Path = _path;
        }
    }
}