using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawnPointPrefab = null; // �� ���� ��ġ �˷��ִ� ������
    [SerializeField] private GameObject enemyPrefab; // �����Ǵ� ���� ������ (���߿� �迭��)
    [SerializeField] private float enemySpawnTime = 1; // �� �����ֱ� 
    [SerializeField] private float enemySpawnLatency = 1; // Ÿ�� ���� �� �� �����ϱ� ���� ���ð�

    private BaseMemoryPool spawnPointMemoryPool; // �� ���� ��ġ�� �˷��ִ� ������Ʈ ����
    private BaseMemoryPool enemyMemoryPool;  // �� ����, Ȱ��/��Ȱ�� ����

    private int numberofEnemiesSpawnedAtOnce = 1; // ���̿� �����Ǵ� ���� ����
    private Vector2Int mapsize = new Vector2Int(100, 100); // �� ũ��

    private void Awake()
    {
        spawnPointMemoryPool = new BaseMemoryPool(enemySpawnPointPrefab);
        enemyMemoryPool = new BaseMemoryPool(enemyPrefab); //(���⵵ ���߿� �迭�� ����� �ҵ�)

        StartCoroutine("SpawnTile");
    }

    private IEnumerator SpawnTile()
    {
        int currentNumber = 0;
        int maximumNumber = 50;

        while (true)
        { // ���ÿ� numberofEnemiesSpawnedAtOnce ���ڸ�ŭ ���� �����ǵ��� �ϴ� �ݺ���
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

        // �� ������Ʈ�� �����ϰ�, ���� ��ġ�� Point�� ��ġ�� ����
        GameObject item = enemyMemoryPool.ActivatePoolItem();
        item.transform.position = point.transform.position;

        // Ÿ�� ������Ʈ�� ��Ȱ��ȭ
        spawnPointMemoryPool.DeactivatePoolItem(point);
    }

}
