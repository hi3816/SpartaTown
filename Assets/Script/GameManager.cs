using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public string playerName;
    public int SelectCharacterIndex = -1;

    [Header("Character Prefabs")]
    public GameObject[] characterPrefabs; // 캐릭터 프리팹 배열

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

    public GameObject GetCharacterPrefab(int index)
    {
        if (index >= 0 && index < characterPrefabs.Length)
        {
            return characterPrefabs[index];
        }
        return null; // 유효하지 않은 인덱스일 경우 null 반환
    }

}
