using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmanage : MonoBehaviour
{
    // ���۹� �� ���� Ȯ�� â
    public GameObject controlPanel;
    public GameObject exitPanel;

    // ���۹� ��ư Ŭ�� �� ����Ǵ� �Լ�
    public void OnControlButtonClick()
    {
        // ���۹� â Ȱ��ȭ
        controlPanel.SetActive(true);
        exitPanel.SetActive(false); // �ٸ� â�� ��Ȱ��ȭ
    }

    // ���� ��ư Ŭ�� �� ����Ǵ� �Լ�
    public void OnExitButtonClick()
    {
        // ���� Ȯ�� â Ȱ��ȭ
        exitPanel.SetActive(true);
        controlPanel.SetActive(false); // �ٸ� â�� ��Ȱ��ȭ
    }

    // â �ݱ�
    public void ClosePanels()
    {
        controlPanel.SetActive(false);
        exitPanel.SetActive(false);
    }
}
