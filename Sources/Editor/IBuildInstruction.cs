namespace MultiBuilder.Sources.Editor
{
    public interface IBuildInstruction
    {
        void Process(BuildSettings settings);
    }
}