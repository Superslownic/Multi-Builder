﻿using System.Xml;
using Sirenix.OdinInspector;
using UnityEngine;
using static Editor.Sources.Constants.Categories;
using static Editor.Sources.Constants.Extensions;

namespace Editor.Sources.Instructions
{
    [CreateAssetMenu(menuName = Main + Instruction + "Set XML Attribute"), InlineEditor]
    public class XMLAttributeValue : ScriptableObject, IBuildInstruction
    {
        [SerializeField, FilePath(Extensions = XML)] private string _file;
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