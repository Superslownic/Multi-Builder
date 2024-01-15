using System.Collections.Generic;
using System.Diagnostics;

namespace Multi_Builder.Editor.Utilities
{
	public static class KeystoreExtensions
	{
		public static IEnumerable<string> GetAliases(string path, string pass)
		{
			ProcessStartInfo info = new ProcessStartInfo
			{
				FileName = "keytool",
				Arguments = $"-list -v -keystore {path} -storepass {pass}",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			using Process process = new Process();

			process.StartInfo = info;
			process.Start();

			while (!process.StandardOutput.EndOfStream)
			{
				string output = process.StandardOutput.ReadLine();

				if (!string.IsNullOrEmpty(output) && output.StartsWith("Alias name:"))
				{
					yield return output.Replace("Alias name:", "").Trim();
				}
			}

			process.WaitForExit();
		}
	}
}