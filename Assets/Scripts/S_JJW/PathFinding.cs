using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    public GameObject Path_ = null;




    //==============================================

    public Node start; //길찾기에서 시작이 될 노드
    public Node end;    //길찾기에서 끝이 될 노드

    private float cellsize; //cell 크기를 나타낼 변수

    [SerializeField] GameObject TargetPos;
    //마우스 우클릭 시 생성될 오브젝트
    //이 오브젝트의 위치값을 Node의 index로 변환 후 길찾기를 함

    //이 스크립트에서 start와 end가 다 정해져야 한다.
    // 받은 start와 end로 pathFinding이 이뤄져야 한다.

    //Grid와 Node에서 받아올 것은 node의 index만 가져와야 한다.

    Vector3[] Path = null; //길찾기에서 찾아진 노드의 index를 가지고 위치값으로 저장할 배열

    int targetIndex = 0; // wayPoint의 인덱스 값

    float speed = 0; //이동 속도

    public bool finding;
    public bool success = false;    //길찾기가 끝났는지 확인

    private Rigidbody Rb = null;
    Vector3 thisPos = Vector3.zero;

    Vector3 SetTargetPos_ = Vector3.zero;

    //======================================================================
    //공중 유닛 이동을 위한 변수

    Interactables.IUnit iUnit = null;

    public Units.BasicUnit unitType;

    public Units.UnitStatType.Base baseStats;

    private bool isMove = false;

    Vector3 Movedis = Vector3.zero;
    Vector3 LookDir = Vector3.zero;
    //=======================================================================

    //유닛의 장애물 판정을 위한 변수
    UnitObsTest UO = null;

    //==========================================
    //유닛의 AI를 위한 bool 변수

    private bool isHold;
    private bool isMoving;
    private Vector3[] PatrolPoint;

    private Units.Player.PlayerUnit UnitMode;

    private RaycastHit hit;

    public bool enemy;
    private int UnitModeNum = 0;
    //===========================================

    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        iUnit = GetComponentInChildren<Interactables.IUnit>();
        cellsize = Grid.gridinstance.Getcellsize;   //Grid에서 설정한 cellsize저장
        baseStats = unitType.baseStats;
        UnitMode = GetComponentInChildren<Units.Player.PlayerUnit>();


        UO = GetComponent<UnitObsTest>();
        UO.UnitObstacle();

        if (enemy == true)
        {
            return;
        }
        else
        {
            speed = UnitMode.speed;
        }
    }

    private void Update()
    {
        if (enemy == true)
        {
            return;
        }
        else
        {
            UnitModeNum = (int)UnitMode._mode;

            // hold나 stop일 때 이동 멈춤
            if (UnitModeNum == 3 || UnitModeNum == 1 || UnitMode.isAtking)
            {
                //Debug.Log("공격중" + UnitMode.isAtking);
                StopCoroutine("FindPath");
                StopCoroutine("MoveUnit");
            }

            if (iUnit.isSelected()) //유닛이 선택이 되고
            {

                if (Input.GetMouseButtonDown(1)) // 마우스 우클릭을 하면
                {
                    if (!baseStats.air) //공중유닛인지 판단
                    {
                        if (unitType.name == "SCV")
                        {
                            Debug.Log("SCV");
                            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                            //int layerMask = 1 << LayerMask.NameToLayer("Sea");
                            // LayerMask layerMask = new LayerMask();

                            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                            {


                                LayerMask layerHit = hit.transform.gameObject.layer;
                                Debug.Log("레이어" + layerHit.value);

                                switch (layerHit.value)
                                {



                                    case 25:
                                        Debug.Log("미네랄 클릭");
                                        gameObject.GetComponentInChildren<Units.Player.scv>().changMinerals();

                                        break;
                                    default:
                                        Debug.Log("다른레이어");

                                        gameObject.GetComponentInChildren<Units.Player.scv>().changNormals();
                                        break;

                                }


                            }
                        }
                        SetTarget();
                    }
                    else
                    {
                        FlyingTarget();
                    }

                }
            }
        }
        //FloyingMoveUnit(Movedis);
    }

    public void StopFathPinding()
    {
        StopCoroutine("FindPath");
        StopCoroutine("MoveUnit");
    }
    // ==========================================================
    //유닛의 현재 위치를 길찾기의 시작 위치로 설정
    public void SetStartPos()
    {
        if (start != null)
        {
            //스타트 노드가 이미 있는 경우 기존의 스타트를 초기화 시킨다.

            start = null;
        }
        start = CurrentPos(); //현재 게임 오브젝트가 있는 위치의 노드

        //스타트 노드를 현재 유닛의 위치아래 노드로 변경
    }
    public Node CurrentPos()
    {
        //Debug.Log(this.transform.position);
        return Grid.gridinstance.NodePoint(this.transform.position, cellsize);
    }
    // ================================================================

    // 마우스 포인트로 찍은 노드를 길찾기의 목표지점으로 설정
    public void SetTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            openSet.Clear();
            closedSet.Clear();
            SetStartPos();
            UnitMode.isAtking = false;

            //마우스 우클릭 시 새로운 길찾기를 위해 Open과 close를 리셋, 시작 위치도 현재 게임 오브젝트의 위치로 초기화

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                Vector3 TargetPos = hit.point;
                //GameObject item = Instantiate(TargetPos, hit.point, Quaternion.identity);
                //마우스에서 Ray를 쏴서 맞은 곳에 오브젝트를 생성
                //목적지를 시각화 하기 위한 오브젝트

                if (end != null) end = null;
                //end값에 이미 어떤 값이 들어가있다면 초기화

                end = Grid.gridinstance.NodePoint(TargetPos, cellsize);

                SetTargetPos_ = TargetPos;
                //end에 hitPos에 대응하는 NodeIndex를 대입
            }

            if (end.walkable == true)
            {
                StopCoroutine("FindPath");
                StopCoroutine("MoveUnit");
                StartCoroutine("FindPath");
            }
            //start와 목적지가 정해졌으면 FindPath함수 실행
        }
    }
    public void SetTarget2(Transform ps)
    {
        Debug.Log("돌아가");
            openSet.Clear();
            closedSet.Clear();
            SetStartPos();
            UnitMode.isAtking = false;

            //마우스 우클릭 시 새로운 길찾기를 위해 Open과 close를 리셋, 시작 위치도 현재 게임 오브젝트의 위치로 초기화

           
           
                Vector3 TargetPos = ps.position;
                //GameObject item = Instantiate(TargetPos, hit.point, Quaternion.identity);
                //마우스에서 Ray를 쏴서 맞은 곳에 오브젝트를 생성
                //목적지를 시각화 하기 위한 오브젝트

                if (end != null) end = null;
        //end값에 이미 어떤 값이 들어가있다면 초기화

        SetStartPos();

                end = Grid.gridinstance.NodePoint(TargetPos, cellsize);

                SetTargetPos_ = TargetPos;

        StartCoroutine("FindPath");



        //start와 목적지가 정해졌으면 FindPath함수 실행

    }

    public void ResetPathFind(Vector3 TargetPos)
    {
        if (end != null) end = null;
        end = Grid.gridinstance.NodePoint(TargetPos, cellsize);
        Debug.Log("길 다시 찾기");
        StopCoroutine("FindPath");
        StopCoroutine("MoveUnit");
        StartCoroutine("FindPath");
    }

    List<Node> openSet = new List<Node>();      // 이웃노드를 저장할 List
    HashSet<Node> closedSet = new HashSet<Node>(); // 이미 검사한 노드를 저장할 Hash

    // =================================================================



    public IEnumerator FindPath()
    {

        //길찾기 함수
        Debug.Log("길찾기 시작");
        openSet.Add(start); //start를 첫 열린 목록에 추가
        if (openSet.Count > 0)
        {
            while (openSet.Count > 0)   //열린 목록에 인자가 없을 때 까지 반복
            {
                Node currentNode = openSet[0]; // CurrentNode은 처음 노드부터_ 유닛의 위치

                //Open에 fCost가 가장 작은 노드를 찾기
                for (int i = 1; i < openSet.Count; i++)
                { //0은 시작 노드이기 때문에 i는 1부터 시작
                    if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }

                //마우스 위치가 이동 가능한 지역인지 확인
                //이동 불가능하다면 선택 불가
                //이동 가능한 지역이면 예외처리

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                // 현재 노드가 목적지면 while문 탈출
                if (currentNode == end)
                {
                    //pathSuccess = true;
                    success = true;
                    targetIndex = 0;
                    StopCoroutine("MoveUnit");
                    StartCoroutine("MoveUnit");
                    Debug.Log("움직여라제발");
               
                    UO.ReSetUnitObstacle();
                    break;
                }

                //이웃 노드를 검색
                foreach (Node neighbour in Grid.gridinstance.GetNeighbours(currentNode))
                {
                    //이동불가 노드 이거나 이미 검색한 노드는 제외
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }


                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    // 현재 노드의 gCost와 현재 노드와 이웃 노드의 거리를 계산

                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        //위에서 계산한 값보다 이웃 노드의 gCost가 크거나 
                        neighbour.gCost = newMovementCostToNeighbour;

                        neighbour.hCost = GetDistance(neighbour, end);

                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
        }
        //길을 찾지 못했을 때 예외처리 필요
        //현재 바다는 이미 walkable이 false이기 때문에 선택되지 않음
        //추후 예외처리가 되면 바꿀 예정

        yield return null;
    }
    public IEnumerator FindPath2()
    {

        //길찾기 함수
        Debug.Log("길찾기 시작");
        openSet.Add(start); //start를 첫 열린 목록에 추가
        if (openSet.Count > 0)
        {
            while (openSet.Count > 0)   //열린 목록에 인자가 없을 때 까지 반복
            {
                Node currentNode = openSet[0]; // CurrentNode은 처음 노드부터_ 유닛의 위치

                //Open에 fCost가 가장 작은 노드를 찾기
                for (int i = 1; i < openSet.Count; i++)
                { //0은 시작 노드이기 때문에 i는 1부터 시작
                    if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    {
                        currentNode = openSet[i];
                    }
                }

                //마우스 위치가 이동 가능한 지역인지 확인
                //이동 불가능하다면 선택 불가
                //이동 가능한 지역이면 예외처리

                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                // 현재 노드가 목적지면 while문 탈출
                if (currentNode == end)
                {
                    //pathSuccess = true;
                    success = true;
                    targetIndex = 0;
                    StopCoroutine("MoveUnit");
                    StartCoroutine("MoveUnit");
                    Debug.Log("움직여라제발");

                    UO.ReSetUnitObstacle();
                    break;
                }

                //이웃 노드를 검색
                foreach (Node neighbour in Grid.gridinstance.GetNeighbours(currentNode))
                {
                    //이동불가 노드 이거나 이미 검색한 노드는 제외
                    if (!neighbour.walkable || closedSet.Contains(neighbour))
                    {
                        continue;
                    }


                    int newMovementCostToNeighbour = currentNode.gCost + GetDistance(currentNode, neighbour);
                    // 현재 노드의 gCost와 현재 노드와 이웃 노드의 거리를 계산

                    if (newMovementCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        //위에서 계산한 값보다 이웃 노드의 gCost가 크거나 
                        neighbour.gCost = newMovementCostToNeighbour;

                        neighbour.hCost = GetDistance(neighbour, end);

                        neighbour.parent = currentNode;

                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                    }
                }
            }
        }
        //길을 찾지 못했을 때 예외처리 필요
        //현재 바다는 이미 walkable이 false이기 때문에 선택되지 않음
        //추후 예외처리가 되면 바꿀 예정

        yield return null;
    }
    //==============================================================================

    //Vector3[] RetracePath(Node startNode, Node endNode)
    //{
    //    //Debug.Log("ggggg");
    //    List<Node> path = new List<Node>();
    //    Node currentNode = endNode;

    //    while (currentNode != startNode)
    //    {
    //        path.Add(currentNode);
    //        currentNode = currentNode.parent;
    //    }
    //    Vector3[] waypoints = SimplifyPath(path);
    //    Array.Reverse(waypoints);
    //    //Debug.Log(waypoints);
    //    return waypoints;
    //}


    ////반복되는 이동을 삭제해주며 웨이포인트를 간단하게 만든다.
    //Vector3[] SimplifyPath(List<Node> path) // 매개변수로 Node형 List를 받는다.
    //{
    //    List<Vector3> waypoints = new List<Vector3>();
    //    Vector2 directionOld = Vector2.zero;

    //    for (int i = 1; i < path.Count; i++)
    //    {
    //        Vector2 directionNew = new Vector2((path[i - 1].gridX - path[i].gridX) / 0.25f, (path[i - 1].gridY - path[i].gridY) / 0.25f);
    //        if (directionNew != directionOld)
    //        {
    //            waypoints.Add(path[i - 1].GetPos(this.transform.position.y, cellsize));
    //        }
    //        directionOld = directionNew;
    //    }
    //    waypoints.Add(start.GetPos(this.transform.position.y, cellsize));
    //    //  Debug.Log(waypoints[1]);
    //    return waypoints.ToArray();
    //}

    //=========================================================================================


    Vector3[] RetracePath2(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        Vector3[] waypoints = Grid.gridinstance.ReturnPosArr(path, cellsize);
        Array.Reverse(waypoints);
        return waypoints;
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        //노드간 거리계산
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        //현재 노드와 이웃노드 사이의 거리 계산
        //Debug.Log(i);

        if (dstX > dstY) return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }

    IEnumerator MoveUnit()
    {
        if (success)
        {
            UnitMode.SwitchMode(Units.Player.PlayerUnit._Mode.MOVE);
            Vector3[] Path = RetracePath2(start, end);   //start와 end사이의 이동 포인트를 저장하는 배열 path

            Vector3 currentWaypoint = this.transform.position;

            while (true)
            {
                if (targetIndex < Path.Length)
                {
                    //Debug.Log("TargetIndex : " + targetIndex);
                    currentWaypoint = Path[targetIndex];

                    float AxisX = currentWaypoint.x - transform.position.x;
                    float AxisY = currentWaypoint.z - transform.position.z;
                    Vector3 Movedis = new Vector3(AxisX, 0, AxisY);

                    float SqrLen = Movedis.sqrMagnitude;
                    float SqrLen2 = Movedis.magnitude;

                    if (/*transform.position.x == currentWaypoint.x && transform.position.z == currentWaypoint.z)*/
                        SqrLen < 1.0f)
                    {
                        targetIndex++;
                        //Debug.Log(targetIndex);
                    }

                    this.transform.LookAt(new Vector3(currentWaypoint.x, this.transform.position.y, currentWaypoint.z));

                    this.transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed * Time.deltaTime);
                    // Rb.MovePosition(currentWaypoint * speed * Time.deltaTime);
                    //Debug.Log("이동");
                    thisPos = this.transform.position;
                    thisPos.y = Grid.gridinstance.NodePoint(currentWaypoint, cellsize).YDepthLB + 0.6f;
                    this.transform.position = thisPos;
                    yield return null;
                }
                else
                {
                    UO.UnitObstacle();
                    UnitMode.SwitchMode(Units.Player.PlayerUnit._Mode.STOP);
                   // Debug.Log("이동 끝");
                    break;
                }
            }
        }
    }

    private void FlyingTarget()
    {
        isMove = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            TargetPos_ = hit.point;
        }

        Movedis = new Vector3(TargetPos_.x, 0, TargetPos_.z);
        LookDir = new Vector3(TargetPos_.x, this.transform.position.y, TargetPos_.z);
        this.transform.LookAt(LookDir);
    }


    Vector3 TargetPos_ = Vector3.zero;
    public void FloyingMoveUnit(Vector3 Dir_)
    {
        Vector3 CurrentPos = new Vector3(this.transform.position.x, 0, this.transform.position.z);
        if (isMove)
        {
            var dir = Dir_ - CurrentPos;
            transform.position += dir.normalized * Time.deltaTime * baseStats.speed;
        }
        if (Vector3.Distance(CurrentPos, Dir_) <= 0.1f)
        {
            isMove = false;
        }
    }
}
