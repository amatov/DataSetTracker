using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTest : MonoBehaviour {

	public Mesh mesh;
	public Material material;
	private Vector3[] positionBuffer = new Vector3[15000];


	// Use this for initialization
	void Start () {

		GeneratePositions ();
	}


	private void GeneratePositions(){


		for (int i = 0; i < 15000; i++)
		{
			positionBuffer [i] = new Vector3 (Random.Range (-100, 100), Random.Range (-100, 100), Random.Range (-100, 100)); 
		}

	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < 15000; i++) {
			Graphics.DrawMesh (mesh, positionBuffer [i], Quaternion.identity, material, 0, null, 0, null, false, false);
			//Graphics.DrawMeshInstancedIndirect(mesh, 0, material, 
		
		}

		GeneratePositions ();
	}
}
