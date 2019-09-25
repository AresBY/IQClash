using System;
using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static event Action OnStartGame;
    public static event Action OnFinishGame;
    [SerializeField] StartGameController StartGameActivator = null;

    private void Awake()
    {
        Ball.OnTriggerGorizontBorder += Ball_OnTriggerGorizontBorder;
    }
    private void Start()
    {
        StartGameActivator.Initializate(StartGameInitializate);
    }

    private void StartGameInitializate()
    {
        OnStartGame?.Invoke();
    }

    private void Ball_OnTriggerGorizontBorder()
    {
        OnFinishGame?.Invoke();
        StartGameActivator.Initializate(StartGameInitializate);
    }
    private void OnDestroy()
    {
        Ball.OnTriggerGorizontBorder -= Ball_OnTriggerGorizontBorder;
    }
}
