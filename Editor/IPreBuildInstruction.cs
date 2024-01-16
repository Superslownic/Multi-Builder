using System;

namespace Multi.Builder
{
	public interface IPreBuildInstruction
	{
		Type[] Dependencies => Array.Empty<Type>();
	}
}