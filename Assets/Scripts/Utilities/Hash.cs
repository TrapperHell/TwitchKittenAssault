using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class Hash {

	private static Hash instance;
	public static Hash Instance {get{if (instance == null) new Hash(); return instance;}}

	public Hash()
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

	// Generates and returns filePath's hash
	public string GenerateHash(string filePath)
	{
		string hash = "";

		if (File.Exists(filePath))
		{
			FileStream stream = File.OpenRead(filePath);
        	hash = GenerateHash(stream);
			stream.Close();
		}
		else
		{
			D.error("File does not exist: " + filePath);
		}

		return hash;
	}

	private string GenerateHash(Stream s)
	{
		string hash = "";

		try
		{
			SHA1 sha1 = SHA1.Create();
			hash = System.BitConverter.ToString(sha1.ComputeHash(s)).Replace("-","").ToLower();
		}
		catch(Exception e)
		{
			D.error(e.ToString());
		}
		
		return hash;
	}
	
	// Encrypts filePath's hash and writes it to hashFilePath
	public void PersistHash(string filePath, string hashFilePath)
	{
		try
		{
			string hash = GenerateHash(filePath);
			string encryptedHash = Cryptography.Instance.Encrypt(hash);
			File.WriteAllText(@hashFilePath, encryptedHash);
		}
		catch(Exception e)
		{
			D.error(e.ToString());
		}
	}
	
	// Reads and decrypts the hash from hashFilePath
	public string ReadHash(string hashFilePath)
	{
		string hash = "";
		
		try
		{
			if (File.Exists(hashFilePath))
			{
				StreamReader sr = new StreamReader(hashFilePath);
				string encryptedHash = sr.ReadToEnd();
				hash = Cryptography.Instance.Decrypt(encryptedHash);
				sr.Close();
			}
			else
			{
				D.error("File does not exist: " + hashFilePath);
			}
		}
		catch(Exception e)
		{
			D.error(e.ToString());
		}
		
		return hash;
	}
	
	// Compares asset's hash to the hash stored in hashAsset.
	public bool ValidateHash(TextAsset asset, TextAsset hashAsset)
	{
		byte[] byteArray = Encoding.UTF8.GetBytes(asset.text);

		string currentHash = GenerateHash(new MemoryStream(byteArray));
		string storedHash = Cryptography.Instance.Decrypt(hashAsset.text);
		
		if (storedHash.Equals(currentHash))
		{
			return true;	
		}
		else
		{
			return false;
		}
	}

	// Compares filePath's hash to the hash stored in hashFilePath.
	public bool ValidateHash(string filePath, string hashFilePath)
	{
		string currentHash = GenerateHash(filePath);
		string storedHash = ReadHash(hashFilePath);
		
		if (storedHash.Equals(currentHash))
		{
			return true;	
		}
		else
		{
			return false;
		}
	}
		
}
