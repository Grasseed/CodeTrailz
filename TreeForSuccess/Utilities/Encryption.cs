using System.Security.Cryptography;

namespace TreeForSuccess.Utilities
{
	public class Encryption
	{
		public class HmacEncryption
		{
			// HMAC Encryption
			public static byte[] Encrypt(byte[] data, byte[] key)
			{
				using (var hmac = new HMACSHA256(key))
				{
					return hmac.ComputeHash(data);
				}
			}
		}
	}
}
