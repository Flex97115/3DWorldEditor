using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlyCamScript : MonoBehaviour {

	public float cameraSensitivity = 90;
	public float climbSpeed = 4;
	public float normalMoveSpeed = 10;
	public float slowMoveFactor = 0.25f;
	public float fastMoveFactor = 3;
	public Text myPos;
	private bool isBlocked = false;

	private float rotationX = 0.0f;
	private float rotationY = 0.0f;

	
	void Start ()
	{
		Screen.lockCursor = false;
	}

	public void setCameraSentivity( int sentivity){
		cameraSensitivity = sentivity;
		}
	public float getCameraSentivity(){
		return cameraSensitivity;
		}

	public void Isblocked( bool isBlocked){
		this.isBlocked = isBlocked;
		}
	public bool getIsBlocked(){
		return isBlocked;
		}
	
	void Update ()
	{
		getPosInText ();

		if (Input.GetKey (KeyCode.C)) {
			rotationX += 1 +  cameraSensitivity * Time.deltaTime;
				}
		if (Input.GetKey (KeyCode.X)) {
			rotationX -= 1 + cameraSensitivity * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.R)) {
			rotationY += 1 +  cameraSensitivity * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.F)) {
			rotationY -= 1 + cameraSensitivity * Time.deltaTime;
		}


		if (!isBlocked) {
						rotationX += Input.GetAxis ("Mouse X") * cameraSensitivity * Time.deltaTime;
						rotationY += Input.GetAxis ("Mouse Y") * cameraSensitivity * Time.deltaTime;
				}
						rotationY = Mathf.Clamp (rotationY, -90, 90);
		
						transform.localRotation = Quaternion.AngleAxis (rotationX, Vector3.up);
						transform.localRotation *= Quaternion.AngleAxis (rotationY, Vector3.left);
				
		
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
		{
			transform.position += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
		else if (Input.GetKey (KeyCode.LeftControl) || Input.GetKey (KeyCode.RightControl))
		{
			transform.position += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
		else
		{

			transform.position += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
			transform.position += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		}
		
		
		if (Input.GetKey (KeyCode.Z)) {transform.position += transform.up * climbSpeed * Time.deltaTime;}
		if (Input.GetKey (KeyCode.Q)) {transform.position -= transform.up * climbSpeed * Time.deltaTime;}
	}

	public void getPosInText(){
		myPos.text = "X: " + transform.position.x.ToString("F1") + "\n" + "Y: " + transform.position.y.ToString("F1") + "\n" + "Z: " + transform.position.z.ToString("F1");
	}
}
