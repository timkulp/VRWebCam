using UnityEngine;
using System.Collections;

public class WebCamApplier : MonoBehaviour {

    private WebCamDevice[] devices = null;
    private WebCamTexture camText;


	// Use this for initialization
	void Start () {
        devices = WebCamTexture.devices;
        if (devices.Length == 0)
            return;

        camText = new WebCamTexture();
        Renderer r = GetComponent<Renderer>();
        r.material.mainTexture = camText;
        camText.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
