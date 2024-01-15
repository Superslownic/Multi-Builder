using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class ProductDescription : IBuildInstruction
  {
    [SerializeField]
    private string _companyName = "company";
    
    [SerializeField]
    private string _productName = "product";
    
    [SerializeField]
    private bool _overrideIdentifier;
    
    [SerializeField, ShowIf(nameof(_overrideIdentifier))]
    private string _packageName;

    [ShowInInspector, HideIf(nameof(_overrideIdentifier)), LabelText("Package Name")]
    private string AutoPackageName => $"com.{_companyName}.{_productName}";

    public void Process(BuildSettings settings)
    {
      PlayerSettings.companyName = _companyName.Trim();
      PlayerSettings.productName = settings.Name = _productName.Trim();
      PlayerSettings.applicationIdentifier = _overrideIdentifier ? _packageName.Trim() : AutoPackageName;
    }
  }
}