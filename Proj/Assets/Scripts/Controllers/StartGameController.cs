using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    private Action StartGameInitializate = null;

    public void Initializate(Action startGameInitializate)
    {
        StartGameInitializate = startGameInitializate;
        enabled = true;
    }

    private void Awake()
    {
        enabled = false;
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.1f);
        StartGameInitializate?.Invoke();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("StartGame");
            enabled = false;
        }
    }
}
