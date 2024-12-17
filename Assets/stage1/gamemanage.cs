using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR;

public class gamemanage : MonoBehaviour
{
    public GameObject player;
    public GameObject heli;
    public Button bt;
    private bool near = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("CenterEyeAnchor");
        heli = GameObject.Find("Helicopter");
        bt.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && heli != null)
        {
            float dis = Vector3.Distance(player.transform.position, heli.transform.position);
            if (dis < 6f)
            {
                if (!near)
                {
                    near = true;
                    bt.gameObject.SetActive(true);
                }
                if (IsButtonOnePressed())
                {
                    TakeOff();
                }
            }
            else
            {
                if (near)
                {
                    near = false;
                    bt.gameObject.SetActive(false);
                }
            }
        }
    }
    bool IsButtonOnePressed()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHand.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            return isPressed;
        }

        return false;
    }
    public void TakeOff()
    {
        SceneManager.LoadScene("stage2");
    }
}
