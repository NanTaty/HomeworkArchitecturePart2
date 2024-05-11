using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[CreateAssetMenu (fileName = "BallFactory", menuName = "BallFactory")]
public class BallFactory : ScriptableObject
{
    [SerializeField] private Ball _green, _blue, _red;
    
    public Ball Get(BallType ballType)
    {
        Ball ballToSpawn = Instantiate(GetBallType(ballType));
        return ballToSpawn;
    }

    private Ball GetBallType(BallType ballType)
    {
        switch (ballType)
        {
             case BallType.Blue:
                 return _blue;
             
             case BallType.Green:
                 return _green;
             
             case BallType.Red:
                 return _red;
             
             default:
                 throw new ArgumentException(nameof(ballType)); 
        }
    }
}
