using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginHandler : MonoBehaviour {

	[SerializeField]
	private SaveLoadSerialized _saveload;
	[SerializeField]
	private Text inputTxt;
	[SerializeField]
	private InputField passText;
	[SerializeField]
	private Text msg;

	private string username;
	private string password;

	private string url;

	public void Login(){
		username = inputTxt.text;
		password = passText.text;
		msg.text = "connecting with database! please wait";
		url = URL.LOGIN;
		StartCoroutine(LoginIE());
		//_saveload.SaveUserData(username,password);
	}
	
	public void Register(){
		Application.LoadLevel("register");
	}
	public void Back(){
		Application.LoadLevel("MainMenu");
	}

	IEnumerator LoginIE() {
		WWW www = new WWW(url + "?username=" + username + "&password=" + password);
		yield return www;
		if(www.text == "true"){
			msg.text = "Logged in correctly!";
			_saveload.SaveUserData(username, password);
		} else {
			msg.text = "Username or Password is incorrect!";
		}
	}

}
