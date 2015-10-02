using UnityEngine;
using System.Collections;

public class SetPivotPyramid : MonoBehaviour {

	GameObject obj;
	Vector3 p; //Pivot value -1..1, calculated from Mesh bounds
	Vector3 last_p; //Last used pivot
	MeshFilter meshFilter; //Mesh Filter of the selected object
	Mesh mesh; //Mesh of the selected object
	Collider col; //Collider of the selected object

	// Use this for initialization
	void Start () {
		obj = this.gameObject;
		RecognizeSelectedObject ();
		mesh = meshFilter.mesh;
		p = Vector3.zero;
		UpdatePivot();
		last_p = p;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdatePivot() { 
		Vector3 diff = Vector3.Scale(mesh.bounds.extents, last_p - p); //Calculate difference in 3d position
		obj.transform.position -= Vector3.Scale(diff, obj.transform.localScale); //Move object position by taking localScale into account
		//Iterate over all vertices and move them in the opposite direction of the object position movement
		Vector3[] verts = mesh.vertices; 
		for(int i=0; i<verts.Length; i++) {
			verts[i] += diff;
		}
		mesh.vertices = verts; //Assign the vertex array back to the mesh
		mesh.RecalculateBounds(); //Recalculate bounds of the mesh, for the renderer's sake
		//The 'center' parameter of certain colliders needs to be adjusted
		//when the transform position is modified
		if(col) {
			if(col is BoxCollider) {
				((BoxCollider) col).center += diff;
			} else if(col is CapsuleCollider) {
				((CapsuleCollider) col).center += diff;
			} else if(col is SphereCollider) {
				((SphereCollider) col).center += diff;
			}
		}
	}

	void UpdatePivotVector() {
		Bounds b = mesh.bounds;
		Vector3 offset = -1 * b.center;
		p = last_p = new Vector3(offset.x / b.extents.x, offset.y / b.extents.y, offset.z / b.extents.z);
	}

	void RecognizeSelectedObject() {
		if(obj) {
			meshFilter = obj.GetComponent(typeof(MeshFilter)) as MeshFilter;
			mesh = meshFilter ? meshFilter.sharedMesh : null;
			if(mesh)
				UpdatePivotVector();
			col = obj.GetComponent(typeof(Collider)) as Collider;
		} else {
			mesh = null;
		}
	}
}
