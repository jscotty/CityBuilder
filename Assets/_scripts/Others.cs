using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Others : MonoBehaviour {

	[SerializeField]
	private GameObject _holder;
	[SerializeField]
	private Button _button;

	private bool res;
	private int width = 100, height = 30;
	Button button;
	

	void Start () {
		SeeOthers();
	}

	public void SeeOthers(){
		StartCoroutine(RegisterCount());
	}
	
	IEnumerator RegisterCount(){
		WWW www = new WWW(URL.OTHERS);
		yield return www;

		SplitOthers(www.text);
	}

	void SplitOthers(string players){
		string[] others = players.Split(',');

		SpawnButtons(others);
	}

	void SpawnButtons(string[] others){
		for (int i = 0; i < others.Length; i++) {
			if(others[i] != ""){
				button = (Button)Instantiate(_button);
				button.transform.SetParent(_holder.transform);

				Vector3 pos = button.transform.position;
				pos.x = _holder.transform.position.x;
				pos.y = (_holder.transform.position.y ) + (i * -100);
				button.transform.position = pos;

				button.GetComponentInChildren<Text>().text = others[i];
			}
		}
	}
}
