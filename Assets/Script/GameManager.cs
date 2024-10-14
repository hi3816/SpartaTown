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
    public GameObject[] characterPrefabs; // ĳ���� ������ �迭

    private void Awake()
    {
        // ���� �Ŵ����� �̹� �����ϸ� ����
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
    }

    public GameObject GetCharacterPrefab(int index)
    {
        if (index >= 0 && index < characterPrefabs.Length)
        {
            return characterPrefabs[index];
        }
        return null; // ��ȿ���� ���� �ε����� ��� null ��ȯ
    }

}
