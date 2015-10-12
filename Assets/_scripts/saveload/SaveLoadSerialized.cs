using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSerialized : MonoBehaviour {

	void Awake(){
		LoadUserData();
	}

	public void SaveUserData(string username, string password){
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/UserData.dat");
		
		UserData userData = new UserData();
		userData.name = username;
		userData.pass = password;
		
		binaryFormatter.Serialize (file, userData);
		file.Close ();
	}

	public bool LoadUserData(){
		if (File.Exists (Application.persistentDataPath + "/UserData.dat")) {
			BinaryFormatter binaryFormatter = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/UserData.dat", FileMode.Open);
			
			UserData userData = (UserData)binaryFormatter.Deserialize(file);
			UserData.username = userData.name;
			UserData.password = userData.pass;

			return true;
		} else {
			return false;
		}
	}
}
