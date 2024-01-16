using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Multi.Builder.Instructions
{
  [Serializable, InlineEditor]
  public class BuildOptions : IPreBuildInstructionSync
  {
    [SerializeField, ToggleLeft] private bool _showInExplorer;
    [SerializeField, ToggleLeft] private bool _developmentBuild;

    [SerializeField, ToggleLeft, ShowIf(nameof(IsDevelopmentBuild))]
    private bool _autoConnectProfiler;

    [SerializeField, ToggleLeft, ShowIf(nameof(AutoConnectProfiler))]
    private bool _deepProfiling;

    public void Process(BuildSettings settings)
    {
      if (_showInExplorer) settings.BuildOptions |= UnityEditor.BuildOptions.ShowBuiltPlayer;
      if (_developmentBuild) settings.BuildOptions |= UnityEditor.BuildOptions.Development;
      if (_autoConnectProfiler) settings.BuildOptions |= UnityEditor.BuildOptions.ConnectWithProfiler;
      if (_deepProfiling) settings.BuildOptions |= UnityEditor.BuildOptions.EnableDeepProfilingSupport;
    }

    private bool IsDevelopmentBuild =>
      _developmentBuild;

    private bool AutoConnectProfiler =>
      _developmentBuild && _autoConnectProfiler;
  }
}