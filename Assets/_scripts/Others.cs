using UnityEngine;
using System.Collections;

public class Others : MonoBehaviour {

	//private string[] others;
	private bool res;

	void Start () {
		StartCoroutine(RegisterCount());
	}
	
	IEnumerator RegisterCount(){
		WWW www = new WWW(URL.OTHERS);
		yield return www;

		SplitOthers(www.text);
	}

	void SplitOthers(string players){
		string[] others = players.Split(',');
		print(others.Length);
	}
}
