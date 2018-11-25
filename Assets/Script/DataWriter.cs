using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class DataWriter
{
	static public void SaveData()
	{
		FileStream fs = File.Create("data.bin");
		BinaryWriter bw = new BinaryWriter(fs);

		string data = "hello world";

		bw.Write(data);

		bw.Close();
		fs.Close();
	}
}

public class DataReader
{
	static public void ReadData()
	{
		FileStream fs = File.Open("data.bin", FileMode.Open);
		BinaryReader br = new BinaryReader(fs);

		string output = br.ReadString();

		Debug.Log("data.bin output" + output);

		br.Close();
		fs.Close();
	}
}
