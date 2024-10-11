using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    public Transform player; // ĳ������ Transform
    public Text playerNameText; // UI �ؽ�Ʈ

    private void Start()
    {
        // GameManager���� �÷��̾� �̸� ��������
        if (GameManager.Instance != null)
        {
            playerNameText.text = GameManager.Instance.playerName;
        }else if (GameManager.Instance == null)
        {
            playerNameText.text = "name";
        }
    }

    private void Update()
    {
        // �÷��̾��� ��ġ�� ���� UI �ؽ�Ʈ ��ġ ������Ʈ
        Vector3 screenPos = Camera.main.WorldToScreenPoint(player.position);
        screenPos.y += 50;
        playerNameText.transform.position = screenPos;
    }
}
