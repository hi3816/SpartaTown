using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    public Transform player; // 캐릭터의 Transform
    public Text playerNameText; // UI 텍스트

    private void Start()
    {
        // GameManager에서 플레이어 이름 가져오기
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
        // 플레이어의 위치에 따라 UI 텍스트 위치 업데이트
        Vector3 screenPos = Camera.main.WorldToScreenPoint(player.position);
        screenPos.y += 50;
        playerNameText.transform.position = screenPos;
    }
}
