using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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

    // �÷��̾� �̸� �� �ʿ��� ������ ����
    public string playerName;


}
