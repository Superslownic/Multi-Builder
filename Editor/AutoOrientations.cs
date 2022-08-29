using System;

namespace Multi.Builder
{
  [Flags]
  public enum AutoOrientations
  {
    Portrait = 1,
    PortraitUpsideDown = 2,
    LandscapeLeft = 4,
    LandscapeRight = 8
  }
}