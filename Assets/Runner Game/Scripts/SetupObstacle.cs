using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupObstacle : MonoBehaviour
{
    [SerializeField] CreateGameObjects createGameObjects;
    private void Start()
    {
        StartCoroutine(CreateObjectRoutine());
    }
    private IEnumerator CreateObjectRoutine()
    {
        float duration = .1f;
        yield return new WaitForSeconds(duration);

        createGameObjects.CreateGameObject("Barrier", Vector3.zero);
    }
}
