using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class MainMenuHandler : MonoBehaviour {

	[SerializeField]
	private Text vText;
	[SerializeField]
	private Text loginmsg;
	[SerializeField]
	private Text loginCount;
	[SerializeField]
	private Text[] welcomeText;

	[SerializeField]
	private SaveLoadSerialized saveload;

	void Start () {
		print (Application.persistentDataPath + "/UserData.dat");
		vText.text = "Version: " + PlayerSettings.bundleVersion;

		if(saveload.LoadUserData()){
			for (int i = 0; i < welcomeText.Length; i++) {
				welcomeText[i].text = UserData.username + " welcome to";
			}
			loginmsg.text = "Play!";
		} else {
			for (int i = 0; i < welcomeText.Length; i++) {
				welcomeText[i].text = "Welcome to";
			}
			loginmsg.text = "Login!";
		}

		StartCoroutine(RegisterCount());
	}

	public void Play(){
		if(!saveload.LoadUserData()){
			Application.LoadLevel("login");
		} else {
			Application.LoadLevel("playScene");
		}
	}

	public void Register(){
		Application.LoadLevel("register");
	}

	public void Credits(){

	}

	IEnumerator RegisterCount(){
		WWW www = new WWW(URL.COUNT);
		yield return www;

		loginCount.text = www.text + " players already played this game!";
	}
}
