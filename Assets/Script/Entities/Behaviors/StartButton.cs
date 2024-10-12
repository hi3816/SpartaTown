using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] PlayerNameInput playerNameInput;
    [SerializeField] CharacterSpawner character;
    public void StartGame() 
    {
        playerNameInput.OnSubmitName();
        SceneManager.LoadScene("SampleScene");
    }
}
