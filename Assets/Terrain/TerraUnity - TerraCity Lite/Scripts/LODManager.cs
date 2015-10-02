/*
	_____  _____  _____  _____  ______
	    |  _____ |      |      |  ___|
	    |  _____ |      |      |     |
	
     U       N       I       T      Y
                                         
	
	TerraUnity Co. - Earth Simulation Tools
	October 2012
	
	http://terraunity.com
	info@terraunity.com
	
	This script is written for Unity 3D Engine.
	
	
	
	HOW TO USE:   This script will manage & switch 3 steps of LOD for prepared scene objects during runtime.
	
	The prepared models must have 3 submeshes named "LOD0", "LOD1" & "LOD2" created in your 3D modelling software.
	
	In Unity, create 2 empty gameobjects each with a "Sphere Collider" & the "LODManager" script attached to them 
	to act as Inner & Outer Triggers and make them children of your model/prefab. Scale these 2 gameobjects as you
	desire. Obviously, the Inner one is smaller than the Outer. In their "LODManager" scripts, Assign "LOD0" & "LOD1"
	for the Inner gameobject and "LOD1" & "LOD2" for the Outer gameobject.
	
	When you've set up prefabs/models in your project, you can use TerraUnity-TerraCity plugin to place models in 
	your scene or manually place them so that "LODManager" script will detect and switch between them based on 
	main camera's (Player) distance from placed models in your scene while playing.
	
	For a complete playable scene including all needed items download the Demo Scene from http://www.terraunity.com
	
	
	
	License: You can freely use this script in your Commercial or Non-Commercial projects.
	
	"This script is a little modified version of Aaron Cross' script."
	Aaron Cross: deepwater3d@gmail.com
*/

using UnityEngine;
using System.Collections;

public class LODManager : MonoBehaviour {
	
	public GameObject LODInner;
	public GameObject LODOuter;
	private Ray ray;
	private GameObject LOD0;
	private GameObject LOD1;
	private GameObject LOD2;
	
	void Awake () {
		foreach (Transform building in Object.FindObjectsOfType(typeof(Transform))) {

			if (building.name.Contains("LOD0")) {
				building.gameObject.GetComponent<MeshRenderer>().enabled = true;
				building.gameObject.SetActive(false);
			}
			if (building.name.Contains("LOD1")) {
				building.gameObject.GetComponent<MeshRenderer>().enabled = true;
				building.gameObject.SetActive(false);
			}
			if (building.name.Contains("LOD2")) {
				building.gameObject.GetComponent<MeshRenderer>().enabled = true;
				building.gameObject.SetActive(true);
			}
		}
	}
	
	void OnTriggerEnter(Collider explorer) {
	
		ray = Camera.main.ViewportPointToRay (new Vector3(0.5f,0.5f,0.5f));

		if (explorer.name == Camera.mainCamera.name) {
			if (Physics.Raycast(ray)) {
				LODInner.SetActive(true);
				LODOuter.SetActive(false);
			}
		}
	}
	
	void OnTriggerExit(Collider explorer) {
	
		ray = Camera.main.ViewportPointToRay (new Vector3(0.5f,0.5f,0.5f));
	
		if (explorer.name == Camera.mainCamera.name) {
			if (Physics.Raycast(ray)) {
				LODInner.SetActive(false);
				LODOuter.SetActive(true);
			}
		}
	}
}