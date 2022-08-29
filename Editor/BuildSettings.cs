using UnityEditor;

namespace Multi.Builder
{
  public sealed class BuildSettings
  {
    public string Path;
    public string Name;
    public string Extension;
    public string Version;
    public int VersionCode;
    public BuildOptions BuildOptions;
    public BuildTarget BuildTarget;
    public BuildTargetGroup BuildTargetGroup;

    public string FullPath =>
      $"{Path.Trim()}/{Name} v.{VersionCode}({Version.Trim()}){Extension}";
  }
}