using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MeshCombine();
	}
	
    void MeshCombine()
    {
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        CombineInstance[] combiners = new CombineInstance[filters.Length];

        for(int i = 0; i < filters.Length; i++)
        {
            combiners[i].mesh = filters[i].sharedMesh;
            combiners[i].transform = filters[i].transform.localToWorldMatrix;
        }

        Mesh finalMesh = new Mesh();
        finalMesh.CombineMeshes(combiners);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;
    }
}
