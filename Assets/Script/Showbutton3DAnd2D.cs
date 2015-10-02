using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Showbutton3DAnd2D : MonoBehaviour {


	public Button[] buttonTab3d;
	public Button[] buttonTab2d;
	// Use this for initialization
	void Start () {
		foreach ( Button myButton in buttonTab3d ){
			myButton.gameObject.SetActive(true);
		}
		foreach ( Button myButton in buttonTab2d ){
			myButton.gameObject.SetActive(false);
		}
	}


	public void show3dbuttons(){

		foreach ( Button myButton in buttonTab3d ){
			myButton.gameObject.SetActive(true);
		}
		foreach ( Button myButton in buttonTab2d ){
			myButton.gameObject.SetActive(false);
		}

	}

	public void show2dbuttons(){
		
		foreach ( Button myButton in buttonTab2d ){
			myButton.gameObject.SetActive(true);
		}
		foreach ( Button myButton in buttonTab3d ){
			myButton.gameObject.SetActive(false);
		}
	}
}
