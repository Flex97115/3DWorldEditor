using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class ManagerSceneScript : MonoBehaviour {

	public bool isSaveMode = false;
	public Canvas myCanvas;
	public Animator panelLevel;
	public Animator panelName;
	public Button[] menuButton;
	public InputField myNameField;
	public Button[] slotButton;
	private string name;
	private string tag = "";
	private Text textButtonClicked = null;
	private bool isLoadMode = false;
	private string newScene;
	private SetButtonScript myButtonScript;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void ExitGame(){
		Application.Quit ();

	}

	public void RetryGame(){
		Application.LoadLevel("Niveau 1 Montagne");
		}

	public void SetIsSaveMode( bool isSaveMode){
		this.isSaveMode = isSaveMode;
		}

	public void OpenSavePanel(){
		panelLevel.enabled = true;
		panelName.enabled = true;
		panelName.SetBool ("isHidden", true);
		panelLevel.SetBool ("isHidden", false);

	}

	public void OpenLoadPanel(){
		panelLevel.enabled = true;
		panelLevel.SetBool ("isHidden", false);
		isLoadMode = true;
		}
	

	public void CloseSavePanel() {
		foreach (Button myButton in slotButton) {
			myButton.enabled = true;
		}

		foreach (Button myMenuButton in menuButton) {
			myMenuButton.enabled = true;
				}
		panelLevel.SetBool ("isHidden", true);
		isLoadMode = false;
		isSaveMode = false;

	}

	public void OnSlotClick(){
		if (isSaveMode) {
			if ( tag != ""){
				string path = "Assets/Scene/"+tag+".unity";
				EditorApplication.SaveScene(path,true);
				myNameField.text = "";
			}
				}
		if (isLoadMode) {

			Debug.Log(newScene);
			isLoadMode = false;
				}
	}

	public void OpenNamePanel(){
		foreach (Button myMenuButton in menuButton) {
			myMenuButton.enabled = false;
		}
		panelName.enabled = true;
		panelName.SetBool("isHidden", false);
		isSaveMode = true;
		}

	public void CloseNamePanel() {
		foreach (Button myMenuButton in menuButton) {
			myMenuButton.enabled = true;
		}
		panelName.SetBool("isHidden", true);
		isSaveMode = false;
	}

	public void Save(){
		if (name != "") {
			OpenSavePanel();
				}
	}

	public void SetName( string name ){
			this.name = name;
		}

	public string GetName() {
		return this.name;
		}
	public bool GetIsSaveMode(){

		return isSaveMode;
	}

	public void IsSaveMode( bool isSaveMode){
		this.isSaveMode = isSaveMode;
	}

	public bool GetIsLoadMode(){
		return isLoadMode;
		}

	public void setNewSceneName( string newScene){
		this.newScene = newScene;
		Application.LoadLevel(this.newScene);
	}

	public void setTag( string tag){
		this.tag = tag;
		OnSlotClick ();
	}
	
}
