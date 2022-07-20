using System;

namespace Editor.Sources
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