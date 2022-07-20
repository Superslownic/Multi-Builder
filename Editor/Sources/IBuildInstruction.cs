namespace Editor.Sources
{
    public interface IBuildInstruction
    {
        void Process(BuildSettings settings);
    }
}