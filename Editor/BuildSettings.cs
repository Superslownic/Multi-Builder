using System.IO;
using Multi.Builder.Constants;
using UnityEditor;
using UnityEngine;

namespace Multi.Builder
{
  public sealed class BuildSettings
  {
    public string Path = "Builds";
    public string Name = Application.productName;
    public string Extension = Extensions.APK;
    public string Version = "0.1";
    public int VersionCode = 1;
    public BuildOptions BuildOptions = BuildOptions.None;
    public BuildTarget BuildTarget = BuildTarget.Android;
    public BuildTargetGroup BuildTargetGroup = BuildTargetGroup.Android;

    public string FullPath =>
      $"{FullDirectory}/{FullName}";

    private string FullDirectory =>
      $"{Directory.GetCurrentDirectory()}/{Path.Trim()}";
    
    private string FullName =>
      $"{Name} {Version.Trim()}({VersionCode}){Extension}";
  }
}