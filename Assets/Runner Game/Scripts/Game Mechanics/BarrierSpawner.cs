using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CommonVariables;

public class BarrierSpawner : MonoBehaviour
{
    #region Unity Fields
    [SerializeField] Transform[] spawnPoints;
    [Header("Keeping minimum anad maximum timeout between spawns")]
    [SerializeField] float minTimeOut;
    [SerializeField] float maxTimeOut;
    [SerializeField] PlayerController player;
    [SerializeField] float pointZOffset;
    [Range(0f, 1f)]
    [SerializeField] float coinPercent;
    [SerializeField] float coinYOffset = .3f;
    #endregion
    #region Fields
    private Vector3 _pos = Vector3.zero;
    private readonly string _barrierName = "Barrier";
    #endregion
    #region Unity Methods
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
    private void Update()
    {
        _pos = transform.position;
        _pos.z = player.transform.position.z + pointZOffset;
        transform.position = _pos;
    }
    #endregion

    private IEnumerator SpawnCoroutine()
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(minTimeOut, maxTimeOut));
            var result = Random.Range(0f, 1f);
            if(result > coinPercent)
            {
                CreateObject(SpawnedObjects.Barrier);
            }
            else
            {
                CreateObject(SpawnedObjects.Coin, coinYOffset);
            }
        }
    }
    private void CreateObject(SpawnedObjects spawnedObject , float yOffset = 0f)
    {
        Vector3 objPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
        objPos.y += yOffset;

        CreateGameObjects.Instance.CreateGameObject(spawnedObject.ToString(), objPos , null);
    }
}
