using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	[SerializeField]
	private GameObject[] objectItems;
	[SerializeField]
	private SaveLoadSerialized saveload;

	private int width = 35, height = 20;
	private float cellWidth = -1.0f, cellHeight = 1.0f;
	private bool _build;

	public bool isBuild {
		get {
			return _build;
		}
	}
	
	private GameObject obj;
	private GameObject objBuild;

	private string sendGrid_url;
	private int count = 0, max = 1;

	private int[,] gridList = new int[,]{
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 0, 0, 1, 0, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 0, 1, 0, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0, 1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1, 0,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1}, //width: 35, height 20
	};

	void Awake(){
		StartCoroutine(GetGrid(UserData.username));
	}

	void Start(){

	}

	public void GenerateGrid(){
		print("ey");
		_build = false;
		if (objBuild != null)
			Destroy(objBuild);
		if (obj != null) {
			Destroy(obj);
			obj = new GameObject ("gridHolder");
		} else 
			obj = new GameObject ("gridHolder");
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				if(gridList[z,x] == 0){

					
				} else if(gridList[z,x] == 1){
					GameObject gridPlane = (GameObject)Instantiate(objectItems[0]);
						gridPlane.transform.SetParent(obj.transform);
						Vector3 gridV = gridPlane.transform.position;
						
						gridV.x = x * cellWidth * -1;
						gridV.z = z * cellHeight * -1;
						gridPlane.transform.position = gridV;

				}
			}
		}

		GridToString();

	}

	public void SetGrid(int x, int z, int type){
			gridList[x,z] = type;
	}
	
	public void PlaceBuilding(int x, int z, int type){
		gridList[x,z] = type;
	}
	
	public void BuildModeNature(){
		_build = true;
		if(obj != null){
			Destroy(obj);
		}
		if (objBuild != null) {
			Destroy(objBuild);
			objBuild = new GameObject ("gridBuildHolder");
		} else 
			objBuild = new GameObject ("gridBuildHolder");
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				if(gridList[z,x] == -1 || gridList[z,x] == 0){
					GameObject gridPlane = (GameObject)Instantiate(objectItems[1]);
					gridPlane.transform.SetParent(objBuild.transform);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
					
				} else if(gridList[z,x] == 1){
					GameObject gridPlane = (GameObject)Instantiate(objectItems[0]);
					gridPlane.transform.SetParent(objBuild.transform);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
					
				}
			}
		}
	}
	
	public void BuildModeStreet(){
		_build = true;
		if(obj != null){
			Destroy(obj);
		}
		if (objBuild != null) {
			Destroy(objBuild);
			objBuild = new GameObject ("gridBuildHolder");
		} else 
			objBuild = new GameObject ("gridBuildHolder");
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				 if(gridList[z,x] == 1){
					GameObject gridPlane = (GameObject)Instantiate(objectItems[0]);
					gridPlane.transform.SetParent(objBuild.transform);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
					
				} else if(gridList[z,x] == 0 || gridList[z,x] == -1){
					GameObject gridPlane = (GameObject)Instantiate(objectItems[1]);
					gridPlane.transform.SetParent(objBuild.transform);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
					
				}
			}
		}
	}
	public void BuildMode(){
		_build = true;
		if(obj != null){
			Destroy(obj);
		}
		if (objBuild != null) {
			Destroy(objBuild);
			objBuild = new GameObject ("gridBuildHolder");
		} else 
			objBuild = new GameObject ("gridBuildHolder");
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				if(gridList[z,x] == 0){
					GameObject gridPlane = (GameObject)Instantiate(objectItems[1]);
					gridPlane.transform.SetParent(objBuild.transform);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
					
				} else if(gridList[z,x] == 1){
					GameObject gridPlane = (GameObject)Instantiate(objectItems[0]);
					gridPlane.transform.SetParent(objBuild.transform);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
					
				}
			}
		}
	}

	void GridToString(){
		string str = "";
		for(int i = 0; i < height; i++) {
			for(int j = 0; j < width; j++) {
				if(i >= max){
					max ++;
					if(max > width){
					} else {
						str = str + ";" + (gridList[i,j]);
					}
				} else {
					count ++;
					if(count == 1){
						str = str + (gridList[i,j]);
					} else 
						str = str + "," + (gridList[i,j]);
				}
			}
		}
		StartCoroutine(SendGrid(str));
	}
	
	IEnumerator SendGrid(string grid) {
		count = 0;
		sendGrid_url = URL.SEND_GRID;
		WWW www = new WWW(sendGrid_url + "?username=" + UserData.username + "&grid=" + grid);
		yield return www;

	}

	IEnumerator GetGrid(string username) {
		sendGrid_url = URL.GET_GRID;
		WWW www = new WWW(sendGrid_url + "?username=" + username);
		yield return www;

		SetGrid(www.text);
	}

	void SetGrid(string grid){
		if(grid != "false"){
			int i = 0, j = 0, num = 1;
			bool res;
			foreach (var row in grid.Split(';')) {
				foreach (var col in row.Trim().Split(',')) {
					res = int.TryParse(col.Trim(), out num);
					if(res)
						gridList[i,j] = int.Parse(col.Trim());
					j ++;
					if(j >= width ){
						j = 0;
					}
				}
				i++;
			}
		}
		GenerateGrid();

	}
	
	public void isBuilding(){
		_build = true;
	}

}
