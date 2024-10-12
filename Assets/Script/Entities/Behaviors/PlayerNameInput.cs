using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField; // 플레이어 이름을 입력받을 InputField
    [SerializeField] private Text displayNameText;      // 플레이어 이름을 표시할 Text

    public void OnSubmitName()
    {
        string playerName = nameInputField.text; // 입력된 이름을 가져옴

        // 입력된 이름이 비어있지 않다면 화면에 표시
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
