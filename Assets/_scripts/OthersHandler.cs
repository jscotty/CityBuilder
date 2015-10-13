using UnityEngine;
using System.Collections;

public class OthersHandler : MonoBehaviour {

	[SerializeField]
	private GameObject _holder;

	private Others _others;

	void Start(){
		_others = GetComponent<Others>();
	}

	public void Go(){

	}

	public void Refresh(){
		_others.SeeOthers();
		_holder.transform.position = new Vector3(_holder.transform.position.x,250,0);
	}

	public void Back(){
		Application.LoadLevel("playScene");
	}
}
