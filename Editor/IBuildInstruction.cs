namespace Multi.Builder
{
    public interface IBuildInstruction
    {
        void Process(BuildSettings settings);
    }
}