//using UnityEngine;
//using System.Collections;

//public class Enemy : MonoBehaviour
//{
//    //적 출현할 위치를 담을 배열
//    public Transform[] points;
//    //적 프리팹을 할당할 변수
//    public GameObject EnemyPrefab;
    
//    //적 발생시킬 주기
//    public float createTime;
//    //적의 최대 발생 개수
//    public int maxEnemy = 10;
//    //게임 종료 여부 변수
//    public bool isGameOver = false;

    
//    public void Start()
//    {
//        //Hierarchy View의 Spawn Point를 찾아 하위에 있는 모든 Transform 컴포넌트를 찾아옴
//        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

//        if (points.Length > 0)
//        {
//            //적 생성 코루틴 함수 호출
//            StartCoroutine(this.CreateEnemy());
//        }
//    }

//    IEnumerator CreateEnemy()
//    {
//        //게임 종료 시까지 무한 루프
//        while (!isGameOver)
//        {
//            //현재 생성된 몬스터 개수 산출
//            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy_Unit").Length;

//            if (monsterCount < maxEnemy)
//            {
//                //적의 생성 주기 시간만큼 대기
//                yield return new WaitForSeconds(createTime);

//                //불규칙적인 위치 산출
//                int idx = Random.Range(1, points.Length);
//                //적의 동적 생성
//                Instantiate(EnemyPrefab, points[idx].position, points[idx].rotation);
//            }
//            else
//            {
//                yield return null;
//            }
//        }
//    }
//}