using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class BuildLocation : IBuildInstruction
  {
    [SerializeField, HideLabel, FolderPath(AbsolutePath = true)]
    private string _path;

    public void Process(BuildSettings settings)
    {
      settings.Path = _path;
    }
  }
}