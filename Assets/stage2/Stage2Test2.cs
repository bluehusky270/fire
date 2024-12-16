using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI 네임스페이스
using UnityEngine.XR;

public class Stage2Test2 : MonoBehaviour
{
    public GameObject player;
    public GameObject pool;
    public Canvas can;
    public GameObject BambiBucketPrefab;  // 물주머니 프리팹
    public AudioClip splashSound;  // 첨벙 소리
    private AudioSource audioSource;  // 오디오 소스
    private bool near = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Helicopter");
        pool = GameObject.Find("Pool");

        if (player == null) Debug.LogError("Player (Helicopter) not found!");
        if (pool == null) Debug.LogError("Pool not found!");

        can.gameObject.SetActive(false);

        // 오디오 소스
        audioSource = GetComponent<AudioSource>();
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

                    TriggerBambiBucketCreation();
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

    // secondary button이 눌렸는지 확인
    bool IsButtonTwoPressed()
    {
        InputDevice rightHand = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        if (rightHand.isValid)
        {
            if (rightHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed))
            {
                return isPressed;
            }
        }
        return false;
    }

    // 물주머니 생성하고 소리 재생 후 씬 전환하는 함수
    public void TriggerBambiBucketCreation()
    {
        // 물주머니를 생성하고 위치를 설정
        GameObject bambiBucket = Instantiate(BambiBucketPrefab, pool.transform.position, Quaternion.identity);

        // 생성된 물주머니의 위치를 새로 설정
        bambiBucket.transform.position = new Vector3(0, 5.8f, 3);

        // 첨벙 소리 재생
        if (audioSource != null && splashSound != null)
        {
            Debug.Log("dd");
            audioSource.PlayOneShot(splashSound);
        }


        // 소리가 끝난 후 씬 전환
        Invoke("LoadNextScene", splashSound.length + 0);  // 소리 길이만큼 기다린 후 씬 전환
    }

    // 씬 전환 함수
    private void LoadNextScene()
    {
        SceneManager.LoadScene("stage3");
    }
}
