using UnityEngine;
using System.Collections;

public class CloudsBehindTrees : MonoBehaviour {

	void Start () {
		renderer.material.renderQueue = 2900;
	}
}
