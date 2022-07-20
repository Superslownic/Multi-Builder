using System.Xml;
using MultiBuilder.Sources.Editor.Constants;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MultiBuilder.Sources.Editor.Instructions
{
    [CreateAssetMenu(menuName = Categories.Instructions + nameof(XMLAttributeValue)), InlineEditor]
    public class XMLAttributeValue : ScriptableObject, IBuildInstruction
    {
        [SerializeField, FilePath(Extensions = Extensions.XML)] private string _file;
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