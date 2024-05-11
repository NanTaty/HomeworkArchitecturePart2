using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBall
{ 
    BallType BallType { get; }

    event Action<BallType> OnBallClicked;

    void Deactivate();

}
