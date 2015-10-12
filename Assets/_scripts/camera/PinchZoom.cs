using UnityEngine;
using System.Collections;

public class PinchZoom : MonoBehaviour {

	[SerializeField]
	private float zoomSpeed = 0.05f;

	void Update(){

		if(Input.touchCount == 2){
			Touch firstTouch = Input.GetTouch(0);
			Touch secondTouch = Input.GetTouch(1);

			Vector2 touchFirstPrevPos = firstTouch.position - firstTouch.deltaPosition;
			Vector2 touchSecondPrevPos = secondTouch.position - secondTouch.deltaPosition;
		
			float prevTouchDeltaMag = (touchFirstPrevPos - touchSecondPrevPos).magnitude;
			float touchDeltaMag = (firstTouch.position - secondTouch.position).magnitude;
		
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			if(Camera.main.orthographic){
				Camera.main.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
				Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 2f);
				Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize, 12f);
			}
		}
	}
}
