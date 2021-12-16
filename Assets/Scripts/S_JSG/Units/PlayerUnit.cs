using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Units.Player
{
    public class PlayerUnit : MonoBehaviour
    {
       public enum _Mode
        {
            IDlE,
            STOP,
            ATTACK,
            PATROL,
            HOLD,
            MOVE

        }

        public UnitStatDisplay statDisplay;

        public BasicUnit unitType;


        public UnitStatType.Base baseStats;

        public Collider[] rangeColliders;//private

        public Transform aggerTarget; //private

      //  private UnitStatDisplay aggroUnit;

        private Enemy.enemyUnit atkUnit;

        private bool hasAggero = false;

        private float atkCooldown;

        public float distance; //private



        private Camera camera;



        private Vector3 destination;


        public float attack;
        public float airattack;
        public float atkspeed;
        public float speed;
        public float armor;
        public float atkRange;
        public float atkUpPlus;

        public int DropCount;
       
        public float eyesight;




        private bool isMove;
        private bool isHold;

        private PathFinding PF = null;


       public _Mode _mode { get; set; }


        private void SetMode()
        {
            if (Input.GetKeyDown(KeyCode.H)) SwitchMode(_Mode.HOLD);
            if (Input.GetKeyDown(KeyCode.A)) SwitchMode(_Mode.ATTACK);
            if (Input.GetKeyDown(KeyCode.S)) SwitchMode(_Mode.STOP);
            if (Input.GetKeyDown(KeyCode.LeftShift)) SwitchMode(_Mode.PATROL);
            if (Input.GetKeyDown(KeyCode.M)) SwitchMode(_Mode.MOVE);
        }

        private void SwitchMode(_Mode UM)
        {
            _mode = UM;
        }
        
        private void Awake()
        {
            camera = Camera.main;
        }

        // Start is called before the first frame update
        void Start()
        {

            PF= GetComponentInParent<PathFinding>();

            _mode = _Mode.IDlE;
            baseStats = unitType.baseStats;


            attack = baseStats.attack;
            airattack = baseStats.airattack;
            atkspeed = baseStats.atkspeed;
            speed = baseStats.speed;
            armor = baseStats.armor;
            atkRange = baseStats.atkRange;
            atkUpPlus = baseStats.attackplus;
            DropCount = baseStats.DrodCount;
            
            eyesight = baseStats.eyesight;


            statDisplay.SetStatatDisplayUnit(baseStats, true);


            RTS.Player.playerManager.instance.supply += baseStats.supply;
          



        }

        // Update is called once per frame
        void Update()
        {
            if (atkCooldown>=-1)
            atkCooldown -= Time.deltaTime;

           // MoveUnit();
         
            SetMode();

            if (!isMove && !isHold)
            {
                checkForEnemyTargets();
            MoveToAggroTarget();
            Attack();
            }

            Debug.Log(_mode);



        }
        public void SetDestinatin(Vector3 dest) //목표지점
        {
            destination = dest;
            isMove = true;
        }
        public void MoveUnit()
        {
            if (isMove)
            {
                var dir = destination - transform.position;
                transform.position += dir.normalized * Time.deltaTime * 5;
            }
            if (Vector3.Distance(transform.position, destination) <= 0.1f)
            {
                isMove = false;

            }
        }
        private void checkForEnemyTargets() //범위안 타겟찾음
        {
           
            
                rangeColliders = Physics.OverlapSphere(transform.position, baseStats.eyesight, UnitHandler.instance.eUnitLayer);

                for (int i = 0; i < rangeColliders.Length;)
                {
                    aggerTarget = rangeColliders[i].gameObject.transform;
                    // aggroUnit = aggerTarget.gameObject.GetComponentInChildren<UnitStatDisplay>();
                    atkUnit = aggerTarget.gameObject.GetComponent<Enemy.enemyUnit>();
                Debug.Log("유닛 찾음");
                    hasAggero = true;
                    break;
                }

        }

        private void Attack()
        {
            if (atkUnit != null)
            {
                if (atkUnit.baseStats.ground == false)
                {
                    if (baseStats.airattack == 0)
                    {
                        return;
                    }
                    else
                    {
                        if (atkCooldown <= 0 && distance <= baseStats.airattackrange)
                        {
                            atkUnit.GetComponentInChildren<UnitStatDisplay>().TakeDamage(baseStats.airattack);
                            //aggroUnit.TakeDamage(baseStats.attack);
                            atkCooldown = baseStats.atkspeed;
                        }

                    }
                }
                else
                {
                    if (baseStats.attack == 0)
                    {
                        return;
                    }
                    else
                    {
                        if (atkCooldown <= 0 && distance <= baseStats.atkRange)
                        {
                            Debug.Log("공격");
                            atkUnit.GetComponentInChildren<UnitStatDisplay>().TakeDamage(baseStats.attack);
                            //aggroUnit.TakeDamage(baseStats.attack);
                            atkCooldown = baseStats.atkspeed;
                        }

                    }
                }
            }


           
        }

        private void MoveToAggroTarget() //타겟을 찾으면 따라감
        {
            if (aggerTarget == null)
            {
                hasAggero = false;
            }

            else
            {
                distance = Vector3.Distance(aggerTarget.position, transform.position);

                if (distance <= baseStats.eyesight)
                {
                    Debug.Log("이동");
                    PF.ResetPathFind(aggerTarget.position);
                }
            }


        }
        

        public void B_UpattackCheck()
        {
            if (baseStats.bionic == false)
            {
                return;
            }

            else if (baseStats.bionic == true)
            {
                attack =  baseStats.attack + (baseStats.attackplus * RTS.Player.playerManager.instance.B_atkUpCount);
                airattack = baseStats.airattack + (baseStats.airattackplus * RTS.Player.playerManager.instance.B_atkUpCount);

            }

        }
        public void B_UparmorCheck()
        {
            if (baseStats.bionic == false)
            {
                return;
            }
            else
            {
                armor = baseStats.armor + (baseStats.armorplus * RTS.Player.playerManager.instance.B_armorUpCount);
            }

        }
        public void M_G_UpattackCheck()
        {
            if (baseStats.mechanic == false||baseStats.ground==false||baseStats.air==true)
            {
                return;
            }
            else if (baseStats.mechanic == true && baseStats.ground == true)
            {
                attack = baseStats.attack + (baseStats.attackplus * RTS.Player.playerManager.instance.M_GroundatkUpCount);
                airattack = baseStats.airattack + (baseStats.airattackplus * RTS.Player.playerManager.instance.M_GroundatkUpCount);
            }
           

        }
        public void M_G_UparmorCheck()
        {
            if (baseStats.mechanic == false || baseStats.ground == false || baseStats.air == true)
            {
                return;
            }
            else if (baseStats.mechanic == true && baseStats.ground == true)
            {
                armor = baseStats.armor + (baseStats.armorplus * RTS.Player.playerManager.instance.M_GroundarmorUpCount);
            }
        }
        public void M_A_UpattackChek()
        {
            if (baseStats.mechanic == false || baseStats.ground == true || baseStats.air == false)
            {
                return;
            }
            else if (baseStats.mechanic == true && baseStats.air == true)
            {
                attack = baseStats.attack + (baseStats.attackplus * RTS.Player.playerManager.instance.M_AiratkUpCount);
                airattack = baseStats.airattack + (baseStats.airattackplus * RTS.Player.playerManager.instance.M_AiratkUpCount);
            }
        }
        public void M_A_UparomorCheck()
        {
            if (baseStats.mechanic == false || baseStats.ground == true || baseStats.air == false)
            {
                return;
            }
            else if (baseStats.mechanic == true && baseStats.air == true)
            {
                armor = baseStats.armor + (baseStats.armorplus * RTS.Player.playerManager.instance.M_AirarmorUpCount);

            }
        }

       

    }
}


