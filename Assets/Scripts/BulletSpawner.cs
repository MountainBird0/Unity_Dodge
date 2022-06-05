using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 탄알의 원본 프리팹
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target; // 조준할 대상
    private float spawnRate;
    private float timeAfterSpawn;

    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            // prefab을 원하는 위치와 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        
    }
}
