using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField; // �÷��̾� �̸��� �Է¹��� InputField
    [SerializeField] private Text displayNameText;      // �÷��̾� �̸��� ǥ���� Text

    public void OnSubmitName()
    {
        string playerName = nameInputField.text; // �Էµ� �̸��� ������

        // �Էµ� �̸��� ������� �ʴٸ� ȭ�鿡 ǥ��
        if (!string.IsNullOrEmpty(playerName))
        {
            if (playerName.Length >= 2 && playerName.Length <= 10)
            {
                displayNameText.text = "Player Name: " + playerName;
                GameManager.Instance.playerName = playerName;
            }
            else 
            {
                displayNameText.text = "Please enter between 2 and 10 characters";
            }
            
        }
        else
        {
            displayNameText.text = "Please enter a valid name.";
        }
    }
}
