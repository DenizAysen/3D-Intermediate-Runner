using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour , IObstacle
{
    public static Action onHit;
    public void Hit()
    {
        onHit?.Invoke();
    }
}
