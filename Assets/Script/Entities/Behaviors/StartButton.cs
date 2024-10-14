using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField; // 플레이어 이름을 입력받을 InputField
    [SerializeField] private Text displayNameText;      // 플레이어 이름을 표시할 Text

    private bool isCharacterSelected = false;  // 캐릭터 선택 여부를 저장
    private bool isNameValid = false;          // 이름이 유효한지 여부를 저장

    public void StartGame() 
    {
        // 캐릭터 선택 및 이름 유효성 검사
        CheckCharacterSelected();
        OnSubmitName();

        // 두 조건을 모두 통과한 경우에만 씬 로드
        if (isCharacterSelected && isNameValid)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void OnSubmitName()
    {
        string playerName = nameInputField.text; // 입력된 이름을 가져옴

        // 입력된 이름이 비어있지 않다면 검사
        if (!string.IsNullOrEmpty(playerName))
        {
            if (playerName.Length >= 2 && playerName.Length <= 10)
            {
                displayNameText.text = "Player Name: " + playerName;
                GameManager.Instance.playerName = playerName;
                isNameValid = true;  // 이름이 유효함
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
        int SelectCharacterIndex = GameManager.Instance.SelectCharacterIndex; // 캐릭터 인덱스를 가져옴

        // 캐릭터가 선택되었는지 확인
        if (SelectCharacterIndex == -1)
        {
            displayNameText.text = "Please select a character.";
            isCharacterSelected = false;
        }
        else
        {
            Debug.Log($"선택된 캐릭터 인덱스: {SelectCharacterIndex}");
            isCharacterSelected = true;  // 캐릭터가 선택됨
        }
    }
}
