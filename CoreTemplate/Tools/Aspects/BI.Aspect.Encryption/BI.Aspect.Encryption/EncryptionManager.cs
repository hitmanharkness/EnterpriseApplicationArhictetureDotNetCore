using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BI.Aspect.Encryption
{
	/// <summary>
	/// Contains basic tools to encrypt and decrypt text.
	/// </summary>
	public class EncryptionManager
	{
		#region Private Constants
		private const string ENCRYPTION_KEY = "bi-inc-key-62284D63-19AB-4DDE-8951-C0CFD17B4BFB";
		private const string SALT = "131A38D7-BA2E-41DD-A11A-2AC53A6300A6";
		#endregion

		#region Static Methods

		/// <summary>
		/// Decrypts a previously encrypted string.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <returns>A decrypted string.</returns>
		public static string Decrypt(string encryptedText) =>
			Decrypt(encryptedText, null);

		/// <summary>
		/// Decrypts a previously encrypted string and returns that value parsed as an integer.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <returns>The decrypted string parsed as an integer.</returns>
		public static int DecryptAsInt(string encryptedText) =>
			int.Parse(Decrypt(encryptedText));

		/// <summary>
		/// Decrypts a previously encrypted string and returns that value parsed as a long.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <returns>The decrypted string parsed as a long.</returns>
		public static long DecryptAsLong(string encryptedText) =>
			long.Parse(Decrypt(encryptedText));

		/// <summary>
		/// Decrypts a previously encrypted string.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <param name="salt">The key salt used to derive the key.</param>
		/// <returns>A decrypted string.</returns>
		public static string Decrypt(string encryptedText, string salt)
		{
			var rijndaelCipher = new RijndaelManaged();
			encryptedText = encryptedText.Replace(' ', '+');
			var encryptedData = Convert.FromBase64String(encryptedText);
			var byteSalt = GetSalt(salt);
			var secretKey = new Rfc2898DeriveBytes(ENCRYPTION_KEY, byteSalt, 100);

			using (var decryptor = rijndaelCipher.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
			{
				using (var memoryStream = new MemoryStream(encryptedData))
				{
					using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
					{
						var plainText = new byte[encryptedData.Length];
						var decryptedCount = cryptoStream.Read(plainText, 0, plainText.Length);
						return Encoding.Unicode.GetString(plainText, 0, decryptedCount);
					}
				}
			}
		}

		/// <summary>
		/// Decrypts a previously encrypted string and returns that value parsed as an integer.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <param name="salt">The key salt used to derive the key.</param>
		/// <returns>The decrypted string parsed as an integer.</returns>
		public static int DecryptAsInt(string encryptedText, string salt) =>
			int.Parse(Decrypt(encryptedText, salt));

		/// <summary>
		/// Decrypts a previously encrypted string and returns that value parsed as a long.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <param name="salt">The key salt used to derive the key.</param>
		/// <returns>The decrypted string parsed as a long.</returns>
		public static long DecryptAsLong(string encryptedText, string salt) =>
			long.Parse(Decrypt(encryptedText, salt));

		/// <summary>
		/// Decrypts a previously encrypted string.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <param name="salt">The integer key salt used to derive the key.</param>
		/// <returns>A decrypted string.</returns>
		public static string Decrypt(string encryptedText, int salt) =>
			Decrypt(encryptedText, salt.ToString());

		/// <summary>
		/// Decrypts a previously encrypted string and returns that value parsed as an integer.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <param name="salt">The integer key salt used to derive the key.</param>
		/// <returns>The decrypted string parsed as an integer.</returns>
		public static int DecryptAsInt(string encryptedText, int salt) =>
			int.Parse(Decrypt(encryptedText, salt.ToString()));

		/// <summary>
		/// Decrypts a previously encrypted string and returns that value parsed as a long.
		/// </summary>
		/// <param name="encryptedText">The encrypted string to decrypt.</param>
		/// <param name="salt">The integer key salt used to derive the key.</param>
		/// <returns>The decrypted string parsed as a long.</returns>
		public static long DecryptAsLong(string encryptedText, int salt) =>
			long.Parse(Decrypt(encryptedText, salt.ToString()));

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="clearText">The string to encrypt.</param>
		/// <returns>A Base64 encrypted string.</returns>
		public static string Encrypt(string clearText) =>
			Encrypt(clearText, null);

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="value">The integer value to encrypt.</param>
		public static string Encrypt(int value) =>
			Encrypt(value.ToString());

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="value">The long value to encrypt.</param>
		public static string Encrypt(long value) =>
			Encrypt(value.ToString());

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="clearText">The string to encrypt.</param>
		/// <param name="salt">The key salt used to derive the key.</param>
		/// <returns>A Base64 encrypted string.</returns>
		public static string Encrypt(string clearText, string salt)
		{
			var rijndaelCipher = new RijndaelManaged();
			var plainText = Encoding.Unicode.GetBytes(clearText);
			var byteSalt = GetSalt(salt);
			var secretKey = new Rfc2898DeriveBytes(ENCRYPTION_KEY, byteSalt, 100);

			using (var encryptor = rijndaelCipher.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16)))
			{
				using (var memoryStream = new MemoryStream())
				{
					using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
					{
						cryptoStream.Write(plainText, 0, plainText.Length);
						cryptoStream.FlushFinalBlock();
						return Convert.ToBase64String(memoryStream.ToArray());
					}
				}
			}
		}

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="value">The integer value to encrypt.</param>
		/// <param name="salt">The key salt used to derive the key.</param>
		/// <returns>A Base64 encrypted string.</returns>
		public static string Encrypt(int value, string salt) =>
			Encrypt(value.ToString(), salt);

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="value">The long value to encrypt.</param>
		/// <param name="salt">The key salt used to derive the key.</param>
		/// <returns>A Base64 encrypted string.</returns>
		public static string Encrypt(long value, string salt) =>
			Encrypt(value.ToString(), salt);

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="clearText">The value to encrypt.</param>
		/// <param name="salt">The integer key salt used to derive the key.</param>
		/// <returns>A Base64 encrypted string.</returns>
		public static string Encrypt(string clearText, int salt) =>
			Encrypt(clearText, salt.ToString());

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="value">The integer value to encrypt.</param>
		/// <param name="salt">The integer key salt used to derive the key.</param>
		/// <returns>A Base64 encrypted string.</returns>
		public static string Encrypt(int value, int salt) =>
			Encrypt(value.ToString(), salt.ToString());

		/// <summary>
		/// Encrypts any string using the Rijndael algorithm.
		/// </summary>
		/// <param name="value">The long value to encrypt.</param>
		/// <param name="salt">The integer key salt used to derive the key.</param>
		/// <returns>A Base64 encrypted string.</returns>
		public static string Encrypt(long value, int salt) =>
			Encrypt(value.ToString(), salt.ToString());

		#endregion

		#region Private Methods

		private static byte[] GetSalt(string extraSalt) =>
			Encoding.ASCII.GetBytes($"{SALT}-{extraSalt}");

		#endregion
	}
}