using UnityEngine;
using System.Collections;

public class BuildNavigation : MonoBehaviour {

	[SerializeField]
	private GameObject[] _panels;

	private GameObject _gridObject;
	private Grid _grid;

	void Start(){
		_gridObject = GameObject.FindGameObjectWithTag("Grid");
		_grid = _gridObject.GetComponent<Grid>();
	}

	public void BuildingBtn(){
		
		_grid.BuildMode();

		_panels[0].SetActive(false);
		_panels[1].SetActive(true);
		_panels[2].SetActive(false);
		_panels[3].SetActive(false);
		_panels[4].SetActive(true);

	}
	public void StreetBtn(){
		_grid.BuildModeStreet();
		_panels[0].SetActive(false);
		_panels[1].SetActive(false);
		_panels[2].SetActive(true);
		_panels[3].SetActive(false);
		_panels[4].SetActive(true);
	}
	public void NatureBtn(){
		_grid.BuildModeNature();
		_panels[0].SetActive(false);
		_panels[1].SetActive(false);
		_panels[2].SetActive(false);
		_panels[3].SetActive(true);
		_panels[4].SetActive(true);
	}
	public void BuildBtn(){
		if(!_grid.isBuild){
			_panels[0].SetActive(false);
			_panels[1].SetActive(false);
			_panels[2].SetActive(false);
			_panels[3].SetActive(false);
			_panels[4].SetActive(false);

			_panels[5].SetActive(false);
		} else {
			_panels[0].SetActive(true);
			_panels[1].SetActive(false);
			_panels[2].SetActive(false);
			_panels[3].SetActive(false);
			_panels[4].SetActive(false);
			
			_panels[5].SetActive(true);
		}
	}
	public void BackBtn(){
		_grid.GenerateGrid();
		_panels[0].SetActive(true);
		_panels[1].SetActive(false);
		_panels[2].SetActive(false);
		_panels[3].SetActive(false);
		_panels[4].SetActive(false);
	}

}
