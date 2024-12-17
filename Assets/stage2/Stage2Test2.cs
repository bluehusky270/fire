using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI ���ӽ����̽�
using UnityEngine.XR;

public class Stage2Test2 : MonoBehaviour
{
    public GameObject player;
    public GameObject pool;
    public Canvas can;
    public GameObject BambiBucketPrefab;  // ���ָӴ� ������
    public AudioClip splashSound;  // ÷�� �Ҹ�
    private AudioSource audioSource;  // ����� �ҽ�
    private bool near = false;
    private bool isBambiBucketCreated = false;  // ���ָӴϰ� �̹� �����Ǿ����� Ȯ���ϴ� ����

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Helicopter");
        pool = GameObject.Find("Pool");

        if (player == null) Debug.LogError("Player (Helicopter) not found!");
        if (pool == null) Debug.LogError("Pool not found!");

        can.gameObject.SetActive(false);

        // ����� �ҽ�
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

                if (IsButtonTwoPressed() && !isBambiBucketCreated)  // ���ָӴϰ� ���� �������� �ʾ�����
                {
                    TriggerBambiBucketCreation();
                    isBambiBucketCreated = true;  // ���ָӴϰ� �����Ǿ����� ǥ��
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

    // secondary button�� ���ȴ��� Ȯ��
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

    // ���ָӴ� �����ϰ� �Ҹ� ��� �� �� ��ȯ�ϴ� �Լ�
    public void TriggerBambiBucketCreation()
    {
        // ���ָӴϸ� �����ϰ� ��ġ�� ����
        GameObject bambiBucket = Instantiate(BambiBucketPrefab, pool.transform.position, Quaternion.identity);

        // ������ ���ָӴ��� ��ġ�� ���� ����
        bambiBucket.transform.position = new Vector3(0, 5.8f, 2);

        // ÷�� �Ҹ� ���
        if (audioSource != null && splashSound != null)
        {
            audioSource.PlayOneShot(splashSound);
        }

        // �Ҹ��� ���� �� �� ��ȯ
        Invoke("LoadNextScene", splashSound.length + 0);  // �Ҹ� ���̸�ŭ ��ٸ� �� �� ��ȯ
    }

    // �� ��ȯ �Լ�
    private void LoadNextScene()
    {
        SceneManager.LoadScene("stage3");
    }
}
