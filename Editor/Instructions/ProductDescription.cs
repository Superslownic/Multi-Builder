using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class ProductDescription : IBuildInstruction
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