using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class manageEditPanel : MonoBehaviour {

	public Animator colorPanel;
	public Animator sizePanel;
	public Animator optionPanel;
	public Animator editPanel;
	public Animator panelAnim;
	public Animator rotationPanel;
	public Slider[] rotationSlider;
	public Slider sizeSlider;
	public GameObject myObject = null;
	public Toggle mouseToggle;
	private Color realColor;
	public FlyCamScript myflycam;
	private bool isOpen = false;
	public onClickScript onClick = null;
	private bool isInMoveMode = false;
	private bool isBlocked = false;





	// Use this for initialization
	void Start () {
		realColor = Color.white;
		myflycam = GameObject.Find ("FlyCam").GetComponent("FlyCamScript") as FlyCamScript;
		foreach (Slider mySlider in rotationSlider) {
			mySlider.enabled = false;
		}
		sizeSlider.enabled = false;


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("h") && panelAnim.GetBool("isHidden")) {
			
			panelAnim.enabled = true;
			panelAnim.SetBool("isHidden",false);
			isOpen = true;
			
		} else if (Input.GetKeyDown ("h") && !panelAnim.GetBool("isHidden"))  {
			panelAnim.SetBool("isHidden",true);
			isOpen = false;
		}

		if (isOpen == true && !isInMoveMode) {
						myflycam.setCameraSentivity (0);
				} else {
			myflycam.setCameraSentivity (90);
				}
		if ( onClick != null){
			if(myObject.tag == "2D"){
				onClick = myObject.transform.GetChild(0).GetComponent("onClickScript") as onClickScript;
			} else {
			onClick = myObject.GetComponent ("onClickScript") as onClickScript;
			}
			bool isDone = onClick.getIsDone ();
				if (isDone){
				isInMoveMode = false;
				editPanel.SetBool ("isHidden", false);
				onClick.setIsDone(false);
				onClick = null;
			}
		}
		if (Input.GetKeyDown("m")) {
			isBlocked = !isBlocked;
			myflycam.Isblocked(isBlocked);
			mouseToggle.isOn = isBlocked;
		}
	
	}
	public void setObject( GameObject myObject){
		
		this.myObject = myObject;
	}
	
	public GameObject getObject(){
		return this.myObject;
	}

	public void OpenColorPanel(){
		colorPanel.enabled = true;
		colorPanel.SetBool ("isHidden", false);
	}
	public void CloseColorPanel(){
		colorPanel.SetBool ("isHidden", true);
	}

	public void OpenSizePanel(){
		sizePanel.enabled = true;
		sizeSlider.enabled = true;
		sizePanel.SetBool ("isHidden", false);
	}
	public void CloseSizePanel(){
		sizeSlider.enabled = false;
		sizePanel.SetBool ("isHidden", true);
	}

	public void OpenOptionPanel(){
		optionPanel.enabled = true;
		optionPanel.SetBool ("isHidden", false);
	}
	public void CloseOptionPanel(){
		optionPanel.SetBool ("isHidden", true);
	}

	public void CloseRotationPanel(){
		rotationPanel.SetBool ("isHidden", true);
		foreach (Slider mySlider in rotationSlider) {
			mySlider.enabled = false;
		}
	}
	public void OpenRotationPanel(){
		foreach (Slider mySlider in rotationSlider) {
			mySlider.enabled = true;
				}
		rotationPanel.enabled = true;
		rotationPanel.SetBool ("isHidden", false);
	}

	public void CloseTransitionEditPanel(){
		editPanel.SetBool ("isHidden", true);
		}
	public void OpenTransitionEditPanel(){
		editPanel.SetBool ("isHidden", false);
		}

	
	public bool CloseEditPanel(){
		editPanel.SetBool ("isHidden", true);
		isOpen = false;
		setObject (null);
		onClick = null;
		return false;
		}
	public bool OpenEditPanel(){
		editPanel.SetBool ("isHidden", false);
		isOpen = true;
		return true;
		}
	public void CloseEditPanelManualy(){

		editPanel.SetBool ("isHidden", true);
		isOpen = false;
		if(myObject.tag == "2D"){
			onClick = myObject.transform.GetChild(0).GetComponent("onClickScript") as onClickScript;
		} else {
			onClick = myObject.GetComponent ("onClickScript") as onClickScript;
		}
		if( myObject.tag == "2D"){
			if( myObject.transform.GetChild(0).renderer.material.color == Color.magenta){
				myObject.transform.GetChild(0).renderer.material.color = realColor;
			}
		} else {
			if (myObject.renderer.material.color == Color.magenta) {
				myObject.renderer.material.color = realColor;
			}
		}
		if (onClick.getIsSelect()) {
			onClick.setIsSelect(false);
				}
		setObject (null);
		onClick = null;
		
	}

	public void setMoveMode(){
		if(myObject.tag == "2D"){
			onClick = myObject.transform.GetChild(0).GetComponent("onClickScript") as onClickScript;
		} else {
			onClick = myObject.GetComponent ("onClickScript") as onClickScript;
		}
		editPanel.SetBool ("isHidden", true);
		onClick.setIsMoveMode (true);
		isInMoveMode = true;
	}

	public void hideEditorPanel(){
		panelAnim.SetBool("isHidden",true);
		isOpen = false;
	}
	
}
