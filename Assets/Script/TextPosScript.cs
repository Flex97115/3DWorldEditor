using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextPosScript : MonoBehaviour {

	public Text myTextPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		updateTextPos ();
	}

	public void updateTextPos(){
		myTextPos.text = "X: " + transform.position.x + "\n" + "Y: " + transform.position.y + "\n" + "Z: " + transform.position.z;
		}
}
