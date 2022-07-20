using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(ProductDescription)), InlineEditor]
    public class ProductDescription : ScriptableObject, IBuildInstruction
    {
        [SerializeField] private string _companyName;
        [SerializeField] private string _productName;

        public void Process(BuildSettings settings)
        {
            PlayerSettings.companyName = _companyName.Trim();
            PlayerSettings.productName = settings.Name = _productName.Trim();
        }
    }
}