using UnityEngine;
using System.Collections;

public class onClickScript : MonoBehaviour {

	public bool isSelect = false;
	public Animator editorPanel;
	public Camera flyCam;
	public bool isMoveMode = false;
	public bool isDone = false;
	FlyCamScript myflycam;
	ManageObject objectManager;
	manageEditPanel editPanelManager;
	private Color realColor;
	private Vector3 mouselocation;
	float X, Y;
	private GameObject myObject;
	// Use this for initialization
	void Start () {
		editorPanel = GameObject.Find ("EditPanel").GetComponent<Animator> ();
		editorPanel.enabled = false;
		myflycam = GameObject.Find ("FlyCam").GetComponent("FlyCamScript") as FlyCamScript;
		objectManager = GameObject.Find ("ObjectManager").GetComponent ("ManageObject") as ManageObject;
		editPanelManager = GameObject.Find ("EditorManager").GetComponent ("manageEditPanel") as manageEditPanel;
		realColor = Color.white;

		if (this.transform.parent != null) {
			myObject = transform.parent.gameObject;
//			myObject.tag = "2D";
				} else {
			myObject = this.gameObject;
//			myObject.tag = "3D";
				}
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = Input.mousePosition;
		pos.z =  10 + (myObject.transform.localScale.x *2);
		
		mouselocation = myflycam.camera.ScreenToWorldPoint (pos);
		
		if (!isMoveMode && isSelect) {
						myflycam.setCameraSentivity (0);
		} else if( !isMoveMode && !isSelect)  {
			myflycam.setCameraSentivity(90);
		} else if (isMoveMode && isSelect) {
						myObject.transform.position = mouselocation;
						myflycam.setCameraSentivity(0);
				} else if (!isMoveMode && isSelect) {
			myflycam.setCameraSentivity (0);
				}
	}

	public void setIsSelect(bool isSelect){
		this.isSelect = isSelect;
		}
	public bool getIsSelect(){
		return isSelect;
		}

	public void setIsMoveMode( bool isMoveMode){
		this.isMoveMode = isMoveMode;
		}
	public bool getIsMoveMode(){
		return isMoveMode;
		}
	public void setIsDone ( bool isDone ){
		this.isDone = isDone;
		}
	public bool getIsDone(){
		return isDone;
		}

	void OnMouseDown(){
		editorPanel.enabled = true;
		if (Input.GetKey (KeyCode.I)){
			Destroy(myObject);
		} else if (!isMoveMode) {
						if (!isSelect) {
							if( objectManager.getObject() == null || editPanelManager.getObject() == null){
								editPanelManager.setObject (myObject.gameObject);
								if( myObject.tag == "2D"){
						myObject.transform.GetChild(0).renderer.material.color = Color.magenta;
								 } else {
						myObject.gameObject.renderer.material.color = Color.magenta;
								}
								
								isSelect = editPanelManager.OpenEditPanel ();
								objectManager.setObject (myObject.gameObject);
							}

						} else {

				if( myObject.tag == "2D"){
					myObject.transform.GetChild(0).renderer.material.color = realColor;
				} else {
					myObject.gameObject.renderer.material.color = realColor;
				}
								isSelect = editPanelManager.CloseEditPanel ();
								objectManager.setObject (null);
								
						}
				} else if (isMoveMode && isSelect) {
			myObject.transform.position = mouselocation;
			isMoveMode = false;
			isDone = true;
				}


		}
}
