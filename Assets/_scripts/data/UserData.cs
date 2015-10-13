using UnityEngine;
using System.Collections;

[System.Serializable] 
public class UserData {

	public static string username = "";
	public static string password = "";
	
	public static string visit_name;

	private string _name;

	private string _pass;

	public string pass {
		get {
			return _pass;
		}
		set {
			_pass = value;
		}
	}

	public string name {
		get {
			return _name;
		}
		set {
			_name = value;
		}
	}
}
