using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPipes : MonoBehaviour
{
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float height;

    private float timer = 0f;
    private void Start()
    {
        SpawnPipe();
    }
    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        GameObject newPipe = Instantiate(pipePrefab);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
        Destroy(newPipe, 7);
    }
}
