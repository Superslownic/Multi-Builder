namespace Multi.Builder
{
  public interface IPreBuildInstructionSync : IPreBuildInstruction
  {
    void Process(BuildSettings settings);
  }
}