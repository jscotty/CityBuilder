using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageHandler : MonoBehaviour {

	[SerializeField]
	private InputField _field;
	[SerializeField]
	private GameObject _msgPanel;
	[SerializeField]
	private bool other;

	private string username, msguser, msg;
	private bool active;

	void Start(){
		if(other){
			username = UserData.visit_name;
		} else {
			username = UserData.username;
		}

		msguser = UserData.username;

		GetMessage();
	}

	void GetMessage(){

	}

	public void WallButton(){
		active = !active;
		_msgPanel.SetActive(active);
	}

	public void SendMessage(){
		if(_field.text != "" && _field.text.Length <= 200){
			msg = _field.text;
			StartCoroutine(SendMessageIE());
		}
	}

	IEnumerator SendMessageIE(){
		WWW www = new WWW(URL.SEND_MESSAGE + "?username=" + username + "&msguser=" + msguser + "&msg="+msg);
		yield return www;
		

	}
	IEnumerator GetMessageIE(){
		WWW www = new WWW(URL.MESSAGE + "?username=" + username);
		yield return www;
	}

}
