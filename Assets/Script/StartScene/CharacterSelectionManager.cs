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
    public Button[] characterButtons; // 캐릭터 선택 버튼들
    private Button selectedButton = null; // 선택된 버튼

    private void Start()
    {
        Color originalColor = characterButtons[0].image.color;

        for (int i = 0; i < characterButtons.Length; i++)
        {
            // 각 버튼에 클릭 이벤트를 연결
            int index = i; // 현재 인덱스를 캡처
            characterButtons[i].onClick.AddListener(() => OnCharacterSelected(characterButtons[index], originalColor, index));
        }
    }

    private void OnCharacterSelected(Button clickedButton, Color originalColor, int characterIndex)
    {
        // 이전에 선택된 버튼이 있다면 색상을 원래대로 되돌림
        if (selectedButton != null)
        {
            // 원래 색상으로 변경 (예시로 White)
            selectedButton.image.color = originalColor;
        }

        // 새로 선택한 버튼의 색상을 변경
        clickedButton.image.color = Color.green;

        // 선택된 버튼을 새로 설정
        selectedButton = clickedButton;

        //캐릭터 외형선택
        GameManager.Instance.SelectCharacterIndex = characterIndex;
    }
}
