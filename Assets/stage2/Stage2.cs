using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    public GameObject BambiBucket; // 물 주머니 프리팹
    public AudioClip splashSound; // 첨벙 소리
    public float splashSoundVolume = 1f; // 소리 크기
    public string targetTag = "Button"; // 클릭할 대상의 태그

    private void Update()
    {
        // VR A 버튼 클릭 시 물체를 클릭했는지 확인
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch)) // VR A 버튼 클릭
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Raycast로 클릭된 오브젝트가 있는지 확인
            if (Physics.Raycast(ray, out hit))
            {
                // 클릭된 오브젝트가 특정 태그를 가진 경우
                if (hit.collider != null && hit.collider.CompareTag(targetTag))
                {
                    // 첨벙 소리 재생
                    AudioSource.PlayClipAtPoint(splashSound, hit.point, splashSoundVolume);

                    // 물 주머니 생성
                    GameObject bambiBucket = Instantiate(BambiBucket, hit.point, Quaternion.identity);

                    // 물 주머니의 생성 위치 수정
                    bambiBucket.transform.position = hit.point + new Vector3(0, 1, 0); // y 좌표를 약간 올려줍니다.
                }
            }
        }
    }
}
