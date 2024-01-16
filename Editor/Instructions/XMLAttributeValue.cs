using System;
using System.Xml;
using Multi.Builder.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class XMLAttributeValue : IPreBuildInstructionSync
  {
    [SerializeField, FilePath(Extensions = Extensions.XML)]
    private string _file;

    [SerializeField] private string _node;
    [SerializeField] private string _attribute;
    [SerializeField] private string _value;

    public void Process(BuildSettings settings)
    {
      var doc = new XmlDocument();
      doc.Load(_file);
      doc.SelectSingleNode(_node).Attributes[_attribute].Value = _value;
      doc.Save(_file);
    }
  }
}