using System;

namespace Multi.Builder
{
  public interface IBuildInstruction
  {
    Type[] Dependencies => Array.Empty<Type>();
    void Process(BuildSettings settings);
  }
}