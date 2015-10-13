using UnityEngine;
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
	[SerializeField]
	private GameObject visitBtn;

	void Start () {
		print (Application.persistentDataPath + "/UserData.dat");
		//vText.text = "Version: " + PlayerSettings.bundleVersion;

		if(saveload.LoadUserData()){
			for (int i = 0; i < welcomeText.Length; i++) {
				welcomeText[i].text = UserData.username + " welcome to";
			}
			visitBtn.SetActive(true);
			loginmsg.text = "Play!";
		} else {
			for (int i = 0; i < welcomeText.Length; i++) {
				welcomeText[i].text = "Welcome to";
			}
			visitBtn.SetActive(false);
			loginmsg.text = "Login!";
		}

		StartCoroutine(RegisterCount());
	}

	public void Play(){
		//print(saveload.LoadUserData());
		if(UserData.username == ""){
			Application.LoadLevel(Scenes.LOGIN);
		} else {
			Application.LoadLevel(Scenes.PLAY_SCENE);
		}
	}

	public void Register(){
		Application.LoadLevel(Scenes.REGISTER);
	}

	public void Credits(){

	}
	
	public void Visit(){
		Application.LoadLevel(Scenes.OTHERS);
	}

	IEnumerator RegisterCount(){
		WWW www = new WWW(URL.COUNT);
		yield return www;

		loginCount.text = "already " + www.text + " registered players!";
	}
}
