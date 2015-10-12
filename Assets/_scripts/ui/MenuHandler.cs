using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {

	[SerializeField]
	private float _speed = 6;
	[SerializeField]
	private Text _txtBuildBtn;

	private GameObject _gridObject;
	private Grid _grid;


	void Start () {
		_gridObject = GameObject.FindGameObjectWithTag("Grid");
		_grid = _gridObject.GetComponent<Grid>();

	}

	void Update () {

	}

	public void Build(){
		if(!_grid.isBuild){
			_grid.isBuilding();
			_txtBuildBtn.text = "Play";
		} else {
			_grid.GenerateGrid();
			_txtBuildBtn.text = "Build";
		}
	}

	public void Play(){
		_grid.GenerateGrid();
	}
}
