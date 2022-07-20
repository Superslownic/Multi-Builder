using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using static Multi.Builder.Constants.Categories;

namespace Multi.Builder.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + "Product Description"), InlineEditor]
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