using UnityEngine;
using System.Collections;

public class AddObjectToGame : MonoBehaviour {


	public Transform cube;
	public Transform cylinder;
	public Transform sphere;
	public Transform pyramid;
	public Transform circle;
	public Transform rectangle;
	public Transform line;
	public Transform square;
	public Camera flyCam;
	private  Vector3 myVector;
	
	// Use this for initialization
	void Start () {
		myVector = new Vector3 (Screen.width / 2, Screen.height / 2, flyCam.nearClipPlane + 15);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addCube(){
		cube.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (cube, cube.position, cube.rotation);
	}

	public void addSphere(){
		sphere.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (sphere, sphere.position, sphere.rotation);
		}

	public void addCylinder(){
		cylinder.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (cylinder, cylinder.position, cylinder.rotation);
		}

	public void addPyramid(){
		pyramid.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (pyramid, pyramid.position, pyramid.rotation);
	}

	public void addCircle(){
		circle.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (circle, circle.position, circle.rotation);
	}

	public void addLine(){
		line.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (line, line.position, line.rotation);
	}

	public void addRectangle() {
		rectangle.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (rectangle, rectangle.position, rectangle.rotation);
	}

	public void addSquare(){
		square.position = flyCam.ScreenToWorldPoint (myVector);
		Instantiate (square, square.position, square.rotation);
	}
}
