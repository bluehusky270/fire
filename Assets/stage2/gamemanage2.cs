using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class gamemanage2 : MonoBehaviour
{
    public GameObject player;
    public GameObject pool;
    public Canvas can;
    private bool near = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Helicopter");
        pool = GameObject.Find("Pool");
        if (player == null) Debug.LogError("Player (CenterEyeAnchor) not found!");
        if (pool == null) Debug.LogError("pool not found!");
        can.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && pool != null)
        {
            float dis = Vector3.Distance(player.transform.position, pool.transform.position);
            if (dis < 40f)
            {
                if (!near)
                {
                    near = true;
                    can.gameObject.SetActive(true);
                }
                if (IsButtonTwoPressed())
                {
                    pump();
                }
            }
            else
            {
                if (near)
                {
                    near = false;
                    can.gameObject.SetActive(false);
                }
            }
        }
    }
    bool IsButtonTwoPressed()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed))
        {
            return isPressed;
        }

        return false;
    }
    public void pump()
    {
        SceneManager.LoadScene("stage3");
    }
}
