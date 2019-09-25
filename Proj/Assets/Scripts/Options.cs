using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public static Options Instance
    {
        get;
        private set;
    }

    [SerializeField] private BallOptions BallScriptable = null;
    public BallOptions BallOptions
    {
        get
        {
            return BallScriptable;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
}
