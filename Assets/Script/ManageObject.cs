using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManageObject : MonoBehaviour {


	GameObject myObject = null;
	public Text lblTextSize;
	public Slider sizeSlider;
	public Slider rotationXSlider;
	public Slider rotationYSlider;
	public Slider rotationZSlider;
	public Text rotationXtext;
	public Text rotationYtext;
	public Text rotationZtext;
	public Toggle gravityToggle; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setObject( GameObject myObject){

		this.myObject = myObject;
		}

	public GameObject getObject(){
		return this.myObject;
		}

	public void setColorGreen(){

		if( myObject.tag == "2D"){
			myObject.transform.GetChild(0).renderer.material.color = Color.green;
		} else {
			myObject.gameObject.renderer.material.color = Color.green;
		}
	}

	public void setColorYellow(){
		if( myObject.tag == "2D"){
			myObject.transform.GetChild(0).renderer.material.color = Color.yellow;
		} else {
			myObject.gameObject.renderer.material.color = Color.yellow;
		}
	}

	public void setColorRed(){
		if( myObject.tag == "2D"){
			myObject.transform.GetChild(0).renderer.material.color = Color.red;
		} else {
			myObject.gameObject.renderer.material.color = Color.red;
		}
	}

	public void setColorWhite(){
		if( myObject.tag == "2D"){
			myObject.transform.GetChild(0).renderer.material.color = Color.white;
		} else {
			myObject.gameObject.renderer.material.color = Color.white;
		}
	}

	public void setColorBlue(){
		if( myObject.tag == "2D"){
			myObject.transform.GetChild(0).renderer.material.color = Color.blue;
		} else {
			myObject.gameObject.renderer.material.color = Color.blue;
		}
	}

	public void setSize( float size){

		Vector3 mySize = new Vector3 (size, size, size);
		myObject.transform.localScale = mySize;
	}

	public void setTextSize( float textSize ){
		lblTextSize.text = textSize.ToString("F1");
	}
	public void setDefaultValue(){
		sizeSlider.value = myObject.transform.localScale.x;
		lblTextSize.text = myObject.transform.localScale.x.ToString("F1");
		rotationXtext.text = myObject.transform.localRotation.x.ToString("F1");
		rotationYtext.text = myObject.transform.localRotation.y.ToString("F1");
		rotationZtext.text = myObject.transform.localRotation.z.ToString("F1");
		rotationXSlider.value = myObject.transform.eulerAngles.x;
		rotationYSlider.value = myObject.transform.eulerAngles.y;
		rotationZSlider.value = myObject.transform.eulerAngles.z;
		if (myObject.rigidbody != null) {
			gravityToggle.enabled = true;
			gravityToggle.isOn = !myObject.rigidbody.useGravity;
				} else {
			gravityToggle.enabled = false;
				}
		}

	public void setGravity(bool isAffect){
		if (isAffect) {
						myObject.rigidbody.useGravity = !isAffect;
						myObject.rigidbody.isKinematic = isAffect;
				} else {
			myObject.rigidbody.useGravity = !isAffect;
			myObject.rigidbody.isKinematic = isAffect;
				}
	}


	public void setXRotation( float x){
		myObject.transform.eulerAngles = new Vector3 ( x, myObject.transform.eulerAngles.y, myObject.transform.eulerAngles.z);
	}

	public void setYRotation( float y){

		myObject.transform.eulerAngles = new Vector3 (myObject.transform.eulerAngles.x, y, myObject.transform.eulerAngles.z);
	}

	public void setZRotation ( float z){
		myObject.transform.eulerAngles = new Vector3 (myObject.transform.eulerAngles.x, myObject.transform.eulerAngles.y, z);
	}

	public void setXTextRotation(float textX){
		rotationXtext.text = textX.ToString("F1");
		}
	public void setYTextRotation(float textY){
		rotationYtext.text = textY.ToString("F1");
	}

	public void setZTextRotation(float textZ){
		rotationZtext.text = textZ.ToString("F1");
	}
	

}
