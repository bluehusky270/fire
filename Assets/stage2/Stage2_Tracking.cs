using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public float altitudeThreshold = 8f; // ��ư�� Ȱ��ȭ�� �� (����: ����)
    public GameObject buttonUI; // ��ư UI ������Ʈ

    void Start()
    {
        // ��ư UI�� ó���� ��Ȱ��ȭ
        if (buttonUI != null)
        {
            buttonUI.SetActive(false);
        }
    }

    void Update()
    {
        // �︮������ ���� �� ��� (Y ��ġ ���)
        float currentAltitude = transform.position.y;

        // ���� ���� �� ���Ϸ� �������� ��ư Ȱ��ȭ
        if (currentAltitude <= altitudeThreshold)
        {
            if (buttonUI != null)
            {
                buttonUI.SetActive(true); // ��ư Ȱ��ȭ
            }
        }
        else
        {
            if (buttonUI != null)
            {
                buttonUI.SetActive(false); // ��ư ��Ȱ��ȭ
            }
        }
    }
}