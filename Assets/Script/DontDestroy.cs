using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	public Button[] myTabButton;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Awake(){
		foreach (Button myButton in myTabButton) {
			DontDestroyOnLoad (myButton.gameObject);
			DontDestroyOnLoad (myButton.transform.GetChild(0));
				}

	}
}
