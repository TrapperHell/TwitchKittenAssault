using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using UnityEngine;
using System.Text;

public class Xml {

	private static Xml instance;
	public static Xml Instance {get{if (instance == null) new Xml(); return instance;}}

	public Xml()
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
	
	
	/*********************************************
	 *XML Read/Write functions.
	 *********************************************
	**/
	
	private void CreateFolderIfNeeded(string filePath)
	{
  		string folder = Path.GetDirectoryName(filePath);
  		if (Directory.Exists(folder) == false)
		{
    		Directory.CreateDirectory(folder);
		}
	}
	
	public void Write(string filePath, Type type, object data)
	{
		XmlSerializer serializer = new XmlSerializer(type);
		CreateFolderIfNeeded(filePath);
		FileStream stream = new FileStream( filePath, FileMode.Create );
		XmlWriter xw = XmlWriter.Create(stream, new XmlWriterSettings{Encoding = Encoding.UTF8});
		serializer.Serialize(xw, data);
		stream.Close();
	}

	public object Read(TextAsset asset, Type type)
	{
		object data = null;

		XmlSerializer serializer = new XmlSerializer(type);
		TextReader tr = new StringReader(asset.text);
		data = serializer.Deserialize( tr );
		return data;
	}
	
	public object Read(string filePath, Type type)
	{
		object data = null;
		if (File.Exists(filePath))
		{
			XmlSerializer serializer = new XmlSerializer(type);
 			FileStream stream = new FileStream ( filePath, FileMode.Open );
 			data = serializer.Deserialize( stream );
 			stream.Close();
		}
		else
		{
			D.error("File does not exist: " + filePath);
		}
		
		return data;
	}
}
