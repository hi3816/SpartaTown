using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // 게임 매니저가 이미 존재하면 삭제
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않음
    }

    // 플레이어 이름 등 필요한 데이터 저장
    public string playerName;


}
