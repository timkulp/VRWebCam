using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private VRInput m_Input;
    [SerializeField]
    private UnityEngine.UI.Text m_DebugDialog;
    [SerializeField]
    private float m_Speed;

    void OnEnable()
    {
        m_Input.OnSwipe += M_Input_OnSwipe;
        m_Input.OnDown += M_Input_OnDown;
    }

    private void M_Input_OnClick()
    {
        throw new System.NotImplementedException();
    }

    private void M_Input_OnDown()
    {
        m_DebugDialog.text = "Fire!";
    }

    void OnDisable()
    {
        m_Input.OnSwipe -= M_Input_OnSwipe;
        m_Input.OnDown -= M_Input_OnDown;
    }

    private void M_Input_OnSwipe(VRInput.SwipeDirection obj)
    {
        switch (obj)
        {
            case VRInput.SwipeDirection.RIGHT:
                m_DebugDialog.text += "Forward\n\r;";
                transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
                break;
            case VRInput.SwipeDirection.LEFT:
                m_DebugDialog.text += "Back\n\r";
                transform.Translate(Vector3.back * m_Speed * Time.deltaTime);
                break;
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
