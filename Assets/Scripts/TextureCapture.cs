using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System;

public class TextureCapture : MonoBehaviour
{
    public GameObject Source;
    public VRInteractiveItem InteractiveItem;
    private Material originalMaterial;

	// Use this for initialization
	void Start () {
        originalMaterial = (GetComponent<Renderer>()).material;
	}

    private void OnEnable()
    {
        InteractiveItem.OnOut += M_InteractiveItem_OnOut;
        InteractiveItem.OnOver += M_InteractiveItem_OnOver;
    }

    private void InteractiveItem_OnClick()
    {
        Renderer r = Source.GetComponent<Renderer>();
        WebCamTexture webCamTexture = r.material.mainTexture as WebCamTexture;

        Color32[] data = new Color32[webCamTexture.width * webCamTexture.height];
        webCamTexture.GetPixels32(data);

        byte[] binaryDataStream = Color32ArrayToByteArray(data);


        /*
        var texture = Instantiate(thisRenderer.material.mainTexture) as Texture2D;

        thisRenderer.material.mainTexture = texture;
        var mipCount = Mathf.Min(3, texture.mipmapCount);

        for(var mip = 0; mip < mipCount; ++mip)
        {
            var cols = texture.GetPixels32(mip);
            for(var i = 0; i < cols.Length; i++)
            {
                cols[i] = Color32.Lerp(cols[i], cols[mip], 0.33f);
            }
            texture.SetPixels32(cols, mip);
        }

        texture.Apply(false);
        */
    }

    private void OnDisable()
    {
        InteractiveItem.OnOut -= M_InteractiveItem_OnOut;
        InteractiveItem.OnOver -= M_InteractiveItem_OnOver;
    }

    private void M_InteractiveItem_OnOver()
    {
        transform.Rotate(new Vector3(0f, 40f * Time.deltaTime, 0f));
        var renderer = GetComponent<Renderer>();
        renderer.material.color = Color.cyan;
        InteractiveItem.OnClick += InteractiveItem_OnClick;

    }

    private void M_InteractiveItem_OnOut()
    {
        var currentYRotation = transform.rotation.y;
        transform.Rotate(new Vector3(0, currentYRotation, 0));
        var renderer = GetComponent<Renderer>();
        renderer.material = originalMaterial;
        InteractiveItem.OnClick -= InteractiveItem_OnClick;

    }

    // Update is called once per frame
    void Update()
    {

    }


    private static byte[] Color32ArrayToByteArray(Color32[] colors)
    {
        if (colors == null || colors.Length == 0)
            return null;

        int lengthOfColor32 = Marshal.SizeOf(typeof(Color32));
        int length = lengthOfColor32 * colors.Length;
        byte[] bytes = new byte[length];

        GCHandle handle = default(GCHandle);
        try
        {
            handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
            IntPtr ptr = handle.AddrOfPinnedObject();
            Marshal.Copy(ptr, bytes, 0, length);
        }
        finally
        {
            if (handle != default(GCHandle))
                handle.Free();
        }

        return bytes;
    }
}
