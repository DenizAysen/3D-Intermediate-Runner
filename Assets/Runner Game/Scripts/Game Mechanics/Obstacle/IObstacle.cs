using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacle 
{
    public float Damage {  get; set; }
    void Hit();
}
