using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CommonVariables 
{
    public enum SpawnedObjects
    {
        Barrier,
        Coin,
        CollectedParticle
    }
    public enum PanelTypes
    {
        Start = 0,
        Failed = 1,
        Success = 2
    }
    public enum PlayerAnimsTriggers
    {
        Hit,
        Die
    }
}
