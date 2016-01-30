using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Cryptography {
	
	private static Cryptography instance;
	public static Cryptography Instance {get{if (instance == null) new Cryptography(); return instance;}}

    // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
    // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
    // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
    private const string initVector = "SzjkO@6X^ae#cSt3";
	private const string passPhrase = "fQ$gjO6WLp9m-L@R";
	private const string salt = "^hZW4G+#WCF%H+9^";

    // This constant is used to determine the keysize of the encryption algorithm.
    private const int keysize = 256;
	
	public Cryptography()
	{
		if (instance != null)
		{
			return;
		}
		else
		{
			instance = this;
		}
	}
	
    public string Encrypt(string plainText)
    {
        byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        //PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
		Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, System.Text.Encoding.UTF8.GetBytes(salt));
        byte[] keyBytes = password.GetBytes(keysize / 8);
        RijndaelManaged symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        cryptoStream.FlushFinalBlock();
        byte[] cipherTextBytes = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();
        return Convert.ToBase64String(cipherTextBytes);
    }

    public string Decrypt(string cipherText)
    {
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        //PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
		Rfc2898DeriveBytes password = new Rfc2898DeriveBytes(passPhrase, System.Text.Encoding.UTF8.GetBytes(salt));
        byte[] keyBytes = password.GetBytes(keysize / 8);
        RijndaelManaged symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
    }
}
