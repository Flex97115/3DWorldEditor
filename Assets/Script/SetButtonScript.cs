using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetButtonScript : MonoBehaviour {

	private ManagerSceneScript sceneManager;
	public Text myText;
	public InputField myInput;
	private string name;
	private bool isSaveMode;
	private bool isLoadMode;
	private bool isSetOnTime = false;
	// Use this for initialization
	void Start () {
		sceneManager = GameObject.Find ("SceneManager").GetComponent ("ManagerSceneScript") as ManagerSceneScript;
	}
	
	// Update is called once per frame
	void Update () {
		isLoadMode = sceneManager.GetIsLoadMode ();
	}

	public void SlotClicked() {
		isSaveMode = sceneManager.GetIsSaveMode ();
		if (isSaveMode){
			name = sceneManager.GetName ();
			if ( name != ""){
				this.name = name;
				myText.text = name;
				sceneManager.setTag(this.tag);
				sceneManager.IsSaveMode(false);
				isSetOnTime = true;
			}
		}

		if (isLoadMode) {
				sceneManager.setNewSceneName (this.tag);
				} 

	}

	public bool IsSetOnTime(){
		return isSetOnTime;
	}


}
