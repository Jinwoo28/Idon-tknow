using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawnPointPrefab = null; // 적 등자 위치 알려주는 프리팹
    [SerializeField] private GameObject enemyPrefab; // 생성되는 적의 프리팹 (나중에 배열로)
    [SerializeField] private float enemySpawnTime = 1; // 적 생성주기 
    [SerializeField] private float enemySpawnLatency = 1; // 타일 생성 후 적 등장하기 까지 대기시간

    private BaseMemoryPool spawnPointMemoryPool; // 적 등장 위치를 알려주는 오브젝트 생성
    private BaseMemoryPool enemyMemoryPool;  // 적 생성, 활성/비활성 관리

    private int numberofEnemiesSpawnedAtOnce = 1; // 동싱에 생성되는 적의 숫자
    private Vector2Int mapsize = new Vector2Int(100, 100); // 맵 크기

    private void Awake()
    {
        spawnPointMemoryPool = new BaseMemoryPool(enemySpawnPointPrefab);
        enemyMemoryPool = new BaseMemoryPool(enemyPrefab); //(여기도 나중에 배열로 맞춰야 할듯)

        StartCoroutine("SpawnTile");
    }

    private IEnumerator SpawnTile()
    {
        int currentNumber = 0;
        int maximumNumber = 50;

        while (true)
        { // 동시에 numberofEnemiesSpawnedAtOnce 숫자만큼 적이 생성되도록 하는 반복문
            for (int i = 0; i < numberofEnemiesSpawnedAtOnce; i++)
            {
                GameObject item = spawnPointMemoryPool.ActivatePoolItem();
                item.transform.position = new Vector3(Random.Range(-mapsize.x * 0.49f, mapsize.x * 0.49f), 1,
                                                      Random.Range(-mapsize.y * 0.49f, mapsize.y * 0.49f));

                StartCoroutine("SpawnEnemy", item);
            }

            currentNumber++;

            if (currentNumber >= maximumNumber)
            {
                currentNumber = 0;
                numberofEnemiesSpawnedAtOnce ++;
            }

            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    private IEnumerator SpawnEnemy(GameObject point)
    {
        yield return new WaitForSeconds(enemySpawnLatency);

        // 적 오브젝트를 생성하고, 적의 위치를 Point의 위치로 설정
        GameObject item = enemyMemoryPool.ActivatePoolItem();
        item.transform.position = point.transform.position;

        // 타일 오브젝트를 비활성화
        spawnPointMemoryPool.DeactivatePoolItem(point);
    }

}
