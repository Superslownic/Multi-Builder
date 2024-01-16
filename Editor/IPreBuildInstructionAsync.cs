using System.Threading.Tasks;

namespace Multi.Builder
{
	public interface IPreBuildInstructionAsync : IPreBuildInstruction
	{
		Task Process(BuildSettings settings);
	}
}