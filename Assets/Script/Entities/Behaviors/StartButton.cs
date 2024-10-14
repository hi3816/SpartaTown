using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField; // �÷��̾� �̸��� �Է¹��� InputField
    [SerializeField] private Text displayNameText;      // �÷��̾� �̸��� ǥ���� Text

    private bool isCharacterSelected = false;  // ĳ���� ���� ���θ� ����
    private bool isNameValid = false;          // �̸��� ��ȿ���� ���θ� ����

    public void StartGame() 
    {
        // ĳ���� ���� �� �̸� ��ȿ�� �˻�
        CheckCharacterSelected();
        OnSubmitName();

        // �� ������ ��� ����� ��쿡�� �� �ε�
        if (isCharacterSelected && isNameValid)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void OnSubmitName()
    {
        string playerName = nameInputField.text; // �Էµ� �̸��� ������

        // �Էµ� �̸��� ������� �ʴٸ� �˻�
        if (!string.IsNullOrEmpty(playerName))
        {
            if (playerName.Length >= 2 && playerName.Length <= 10)
            {
                displayNameText.text = "Player Name: " + playerName;
                GameManager.Instance.playerName = playerName;
                isNameValid = true;  // �̸��� ��ȿ��
            }
            else
            {
                displayNameText.text = "Please enter between 2 and 10 characters";
                isNameValid = false;
            }
        }
        else
        {
            displayNameText.text = "Please enter a valid name.";
            isNameValid = false;
        }
    }

    public void CheckCharacterSelected()
    {
        int SelectCharacterIndex = GameManager.Instance.SelectCharacterIndex; // ĳ���� �ε����� ������

        // ĳ���Ͱ� ���õǾ����� Ȯ��
        if (SelectCharacterIndex == -1)
        {
            displayNameText.text = "Please select a character.";
            isCharacterSelected = false;
        }
        else
        {
            Debug.Log($"���õ� ĳ���� �ε���: {SelectCharacterIndex}");
            isCharacterSelected = true;  // ĳ���Ͱ� ���õ�
        }
    }
}
