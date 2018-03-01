using System;
using BI.Aspect.Encryption;

namespace TestEncryption
{
	internal class Program
	{
		public enum EncryptType
		{
			Default = 0,
			String = 1,
			Int = 2,
			Long = 3
		}

		private static void WriteTypeMessage(EncryptType eType)
		{
			switch (eType)
			{
				case EncryptType.Default:
					Console.BackgroundColor = ConsoleColor.Black;
					break;
				case EncryptType.String:
					Console.BackgroundColor = ConsoleColor.Red;
					break;
				case EncryptType.Int:
					Console.BackgroundColor = ConsoleColor.Green;
					break;
				case EncryptType.Long:
					Console.BackgroundColor = ConsoleColor.Yellow;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(eType), eType, null);
			}
			Console.Write(eType);
			Console.ResetColor();
		}

		private static void WriteMessageInColor(EncryptType firstType, EncryptType secondType, EncryptType thirdType)
		{
			Console.Write("-- Encrypt using ");
			WriteTypeMessage(firstType);
			Console.Write(" using Salt ");
			WriteTypeMessage(secondType);
			Console.Write(" and Decrypt as ");
			WriteTypeMessage(thirdType);
			Console.WriteLine(" --");
		}

		private static void Main()
		{
			const int intValue = 588733;
			const long longValue = long.MaxValue;
			const int intSalt = 75410;
			const string stringValue = "Rodolfo";
			const string stringSalt = "FDCSDX";

			Console.ForegroundColor = ConsoleColor.White;
			//Console.WriteLine("-- Using Encrypt string and Decrypt as string --");
			WriteMessageInColor(EncryptType.String, EncryptType.Default, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + stringValue);
			Console.WriteLine("Using default salt value in encryption manager.");
			Console.WriteLine();
			var encryptedValue = EncryptionManager.Encrypt(stringValue);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt string and salt string and Decrypt as string --");
			WriteMessageInColor(EncryptType.String, EncryptType.String, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + stringValue);
			Console.WriteLine("Using salt: " + stringSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(stringValue, stringSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue, stringSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt string and salt integer and Decrypt as string --");
			WriteMessageInColor(EncryptType.String, EncryptType.Int, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + stringValue);
			Console.WriteLine("Using salt: " + intSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(stringValue, intSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue, intSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt integer and Decrypt as string --");
			WriteMessageInColor(EncryptType.Int, EncryptType.Default, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + intValue);
			Console.WriteLine("Using default salt value in encryption manager.");
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(intValue);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt integer and Decrypt as integer --");
			WriteMessageInColor(EncryptType.Int, EncryptType.Default, EncryptType.Int);
			Console.WriteLine("Encrypting Value: " + intValue);
			Console.WriteLine("Using default salt value in encryption manager.");
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(intValue);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as integer: " + EncryptionManager.DecryptAsInt(encryptedValue));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt integer and salt integer and Decrypt as string --");
			WriteMessageInColor(EncryptType.Int, EncryptType.Int, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + intValue);
			Console.WriteLine("Using salt: " + intSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(intValue, intSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue, intSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt integer and salt integer and Decrypt as integer --");
			WriteMessageInColor(EncryptType.Int, EncryptType.Int, EncryptType.Int);
			Console.WriteLine("Encrypting Value: " + intValue);
			Console.WriteLine("Using salt: " + intSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(intValue, intSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as integer: " + EncryptionManager.DecryptAsInt(encryptedValue, intSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt integer and salt string and Decrypt as string --");
			WriteMessageInColor(EncryptType.Int, EncryptType.String, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + intValue);
			Console.WriteLine("Using salt: " + stringSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(intValue, stringSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue, stringSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt integer and salt string and Decrypt as integer --");
			WriteMessageInColor(EncryptType.Int, EncryptType.String, EncryptType.Int);
			Console.WriteLine("Encrypting Value: " + intValue);
			Console.WriteLine("Using salt: " + stringSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(intValue, stringSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as integer: " + EncryptionManager.DecryptAsInt(encryptedValue, stringSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt long and Decrypt as string --");
			WriteMessageInColor(EncryptType.Long, EncryptType.Default, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + longValue);
			Console.WriteLine("Using default salt value in encryption manager.");
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(longValue);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt long and Decrypt as long --");
			WriteMessageInColor(EncryptType.Long, EncryptType.Default, EncryptType.Long);
			Console.WriteLine("Encrypting Value: " + longValue);
			Console.WriteLine("Using default salt value in encryption manager.");
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(longValue);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as long: " + EncryptionManager.DecryptAsLong(encryptedValue));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt long and salt integer and Decrypt as string --");
			WriteMessageInColor(EncryptType.Long, EncryptType.Int, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + longValue);
			Console.WriteLine("Using salt: " + intSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(longValue, intSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue, intSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt long and salt integer and Decrypt as long --");
			WriteMessageInColor(EncryptType.Long, EncryptType.Int, EncryptType.Long);
			Console.WriteLine("Encrypting Value: " + longValue);
			Console.WriteLine("Using salt: " + intSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(longValue, intSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as long: " + EncryptionManager.DecryptAsLong(encryptedValue, intSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt long and salt string and Decrypt as string --");
			WriteMessageInColor(EncryptType.Long, EncryptType.String, EncryptType.String);
			Console.WriteLine("Encrypting Value: " + longValue);
			Console.WriteLine("Using salt: " + stringSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(longValue, stringSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as string: " + EncryptionManager.Decrypt(encryptedValue, stringSalt));
			Console.WriteLine();
			Console.WriteLine();

			//Console.WriteLine("-- Using Encrypt long and salt string and Decrypt as long --");
			WriteMessageInColor(EncryptType.Long, EncryptType.String, EncryptType.Long);
			Console.WriteLine("Encrypting Value: " + longValue);
			Console.WriteLine("Using salt: " + stringSalt);
			Console.WriteLine();
			encryptedValue = EncryptionManager.Encrypt(longValue, stringSalt);
			Console.WriteLine("Encrypted value: " + encryptedValue);
			Console.WriteLine();
			Console.WriteLine("Decrypted value as long: " + EncryptionManager.DecryptAsLong(encryptedValue, stringSalt));
			Console.WriteLine();
			Console.WriteLine();

			Console.ReadLine();
		}
	}
}