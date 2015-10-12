using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterHandler : MonoBehaviour {

	[SerializeField]
	private InputField[] inputTxt;
	[SerializeField]
	private Text msg;
	[SerializeField]
	private SaveLoadSerialized _saveload;

	private string url, username, password;

	public void Register(){

		if(!hasName()){
			msg.text = "Please enter your name!";
		} else if(!hasCorrectPass()){
			msg.text = "Your passwords do not match!";
		} else if(!hasCorrectPassSize()){
			msg.text = "Please make sure your password has a minimum size of 5 characters";
		} else {
			username = inputTxt[0].text;
			password = inputTxt[1].text;

			msg.text = "Connecting to database please wait";
			url = URL.REGISTER;
			StartCoroutine(RegisterIE());
		}
	}
	public void Login(){
		Application.LoadLevel("login");
	}
	
	public void Back(){
		Application.LoadLevel("MainMenu");
	}

	private bool hasCorrectPass(){
		return (inputTxt[1].text == inputTxt[2].text);
	}

	private bool hasCorrectPassSize(){
		return (inputTxt[1].text.Length >= 5);
	}
	private bool hasName(){
		return (inputTxt[0].text.Length >= 1);
	}
	IEnumerator RegisterIE() {
		WWW www = new WWW(url + "?username=" + username + "&password=" + password);
		yield return www;
		if(www.text == "true"){
			msg.text = "Registered correctly!";
			_saveload.SaveUserData(username, password);
		} else {
			msg.text = "username already excists!";
		}
	}
}

