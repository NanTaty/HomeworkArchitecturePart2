using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour, IBall, IClickable
{
    [SerializeField] private BallType _ballType;

    public BallType BallType => _ballType;

    public event Action<BallType> OnBallClicked;

    public void Click()
    {
        OnBallClicked?.Invoke(_ballType);
        Deactivate();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
