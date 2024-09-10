using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    #region Unity Fields
    [SerializeField] Transform[] spawnPoints;
    [Header("Keeping minimum anad maximum timeout between spawns")]
    [SerializeField] float minTimeOut;
    [SerializeField] float maxTimeOut;
    [SerializeField] PlayerController player;
    [SerializeField] float pointZOffset;
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
            CreateGameObjects.Instance.CreateGameObject(_barrierName, spawnPoints[Random.Range(0, spawnPoints.Length)].position, null);
        }
    }
}
