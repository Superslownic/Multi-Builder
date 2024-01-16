using System.Collections.Generic;

namespace Multi.Builder.Instructions
{
	public class KeystoreMeta
	{
		public string KeystorePassword;
		public Dictionary<string, string> AliasPassword = new();
	}
}