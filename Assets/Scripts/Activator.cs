using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            var halo = gameObject.GetComponent("Halo") as Behaviour;
            halo.enabled = !halo.enabled;        
        }
	}
}
