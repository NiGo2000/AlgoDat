using UnityEngine;
using System.Collections;

public class NodeTag : MonoBehaviour {

    void Awake()
    {
        this.gameObject.tag = Tags.NodePrefab;
    }
	
}
