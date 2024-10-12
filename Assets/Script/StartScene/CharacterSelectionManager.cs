using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CharacterType
{
    Peng,
    Knight
}

public class CharacterSelectionManager : MonoBehaviour
{
    public Button[] characterButtons; // ĳ���� ���� ��ư��
    private Button selectedButton = null; // ���õ� ��ư

    private void Start()
    {
        Color originalColor = characterButtons[0].image.color;

        for (int i = 0; i < characterButtons.Length; i++)
        {
            // �� ��ư�� Ŭ�� �̺�Ʈ�� ����
            int index = i; // ���� �ε����� ĸó
            characterButtons[i].onClick.AddListener(() => OnCharacterSelected(characterButtons[index], originalColor, index));
        }
    }

    private void OnCharacterSelected(Button clickedButton, Color originalColor, int characterIndex)
    {
        // ������ ���õ� ��ư�� �ִٸ� ������ ������� �ǵ���
        if (selectedButton != null)
        {
            // ���� �������� ���� (���÷� White)
            selectedButton.image.color = originalColor;
        }

        // ���� ������ ��ư�� ������ ����
        clickedButton.image.color = Color.green;

        // ���õ� ��ư�� ���� ����
        selectedButton = clickedButton;

        //ĳ���� ��������
        GameManager.Instance.SelectCharacterIndex = characterIndex;
    }
}
