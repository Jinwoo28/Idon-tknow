using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawnPointPrefab = null; // 적 등자 위치 알려주는 프리팹
    [SerializeField] private GameObject[] enemyPrefab = null; // 생성되는 적의 프리팹 배열
    [SerializeField] private float enemySpawnTime = 1; // 적 생성주기 
    [SerializeField] private float enemySpawnLatency = 1; // 타일 생성 후 적 등장하기 까지 대기시간
    




}
