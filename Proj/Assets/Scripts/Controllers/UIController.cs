using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject Message = null;
   
    private  void Awake()
    {
        GameController.OnStartGame += GameController_OnStartGame;
        GameController.OnFinishGame += GameController_OnFinishGame;
    }

    private void UpdateMessage(bool state)
    {
        Message.SetActive(state);
    }

    private void GameController_OnFinishGame()
    {
        UpdateMessage(true);
    }

    private void GameController_OnStartGame()
    {
        UpdateMessage(false);
    }

    private void OnDestroy()
    {
        GameController.OnStartGame -= GameController_OnStartGame;
        GameController.OnFinishGame -= GameController_OnFinishGame;
    }
}
