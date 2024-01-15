using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class BuildLocation : IBuildInstruction
  {
    [SerializeField, HideLabel, FolderPath(AbsolutePath = true, RequireExistingPath = true)]
    private string _path = "Builds";

    public void Process(BuildSettings settings)
    {
      settings.Path = _path;
    }
  }
}