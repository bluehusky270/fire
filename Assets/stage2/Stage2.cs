using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    public GameObject BambiBucket; // �� �ָӴ� ������
    public AudioClip splashSound; // ÷�� �Ҹ�
    public float splashSoundVolume = 1f; // �Ҹ� ũ��
    public string targetTag = "Button"; // Ŭ���� ����� �±�

    private void Update()
    {
        // VR A ��ư Ŭ�� �� ��ü�� Ŭ���ߴ��� Ȯ��
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) // VR A ��ư Ŭ��
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycast�� Ŭ���� ������Ʈ�� �ִ��� Ȯ��
            if (Physics.Raycast(ray, out hit))
            {
                // Ŭ���� ������Ʈ�� Ư�� �±׸� ���� ���
                if (hit.collider != null && hit.collider.CompareTag(targetTag))
                {
                    // ÷�� �Ҹ� ���
                    AudioSource.PlayClipAtPoint(splashSound, hit.point, splashSoundVolume);

                    // �� �ָӴ� ����
                    GameObject bambiBucket = Instantiate(BambiBucket, hit.point, Quaternion.identity);

                    // �� �ָӴ��� ���� ��ġ ����
                    bambiBucket.transform.position = hit.point + new Vector3(0, 1, 0); // y ��ǥ�� �ణ �÷��ݴϴ�.
                }
            }
        }
    }
}
