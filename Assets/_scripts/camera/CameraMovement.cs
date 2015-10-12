using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	[SerializeField]
	private float _speed = 0.0001f;
	[SerializeField]
	private float _maxX = 30f;
	[SerializeField]
	private float _minZ = -20f;

	private float _maxZ = -6f,_minX = 2f;

	private Rigidbody _body;
	private Vector3 _velocity;

	private bool _rotating;
	private string _dir;
	private Grid _grid;

	private bool _move = false;


	void Start () {
		GameObject grid = GameObject.FindGameObjectWithTag(Refs.TAG_GRID);
		if(grid != null){
			_grid = grid.GetComponent<Grid>();
		}
		_body = this.GetComponent<Rigidbody>();

	}

	void Update(){
		if(!_grid.isBuild){
			Move ();
		} else {
			if(_move){
				Move ();
			}
		}
	}

	void Move(){
		if(Input.touchCount == 1){
			Touch firstTouch = Input.GetTouch(0);
				
			Vector2 deltaPos = firstTouch.deltaPosition;

			if(deltaPos.x/7 > 1 || deltaPos.y > 1 || deltaPos.x/7 < -1 || deltaPos.y < -1){
				Vector3 moveVelocity = _body.velocity;
				
				moveVelocity.x = deltaPos.x/7;
				moveVelocity.z = deltaPos.y/7;
				//print("z: " + transform.position.z + " max " + _maxZ + " min " + _minZ + " | x: " + transform.position.x + " max " + _maxX + " min " + _minX);
				if(deltaPos.y > 0 && transform.position.z <= _minZ || deltaPos.y < 0 && transform.position.z >= _maxZ){
					moveVelocity.z = 0;
				}
				if(deltaPos.x > 0 && transform.position.x <= _minX || deltaPos.x < 0 && transform.position.x >= _maxX){
					moveVelocity.x = 0;
				}
				_body.velocity = moveVelocity * -_speed;
			}
		} else {
			Vector3 moveVelocity = new Vector3(0,0,0);
			_body.velocity = moveVelocity;
		}
	}

	public void MoveToggle(){
		_move = !_move;
	}

}
