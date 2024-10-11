using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]PlayerNameInput playerNameInput;
    public void StartGame() 
    {
        playerNameInput.OnSubmitName();
    }
}
