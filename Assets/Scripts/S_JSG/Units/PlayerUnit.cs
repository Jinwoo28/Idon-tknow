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
            IDLE,
            STOP,
            PATROL,
            HOLD,
            MOVE,
            Attack
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



        private Camera Mcamera;



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


   


        private bool AutoAtk = false;   //자동공격이 가능한지 여부
        public bool isAtking = false;   //현재 공격중인지 여부
        private bool search = false;

        Interactables.IUnit iUnit = null;

        private PathFinding PF = null;
        public _Mode _mode { get; set; }

        private void Awake()
        {
            Mcamera = Camera.main;
        }

        void Start()
        {

            PF = GetComponentInParent<PathFinding>();
          
            _mode = _Mode.STOP;
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

            iUnit = GetComponent<Interactables.IUnit>();
        }

        void Update()
        {
            if (atkCooldown >= -1)
                atkCooldown -= Time.deltaTime;

            AutoAtkSetting();

            if (_mode != _Mode.MOVE && _mode != _Mode.HOLD)
            {
                checkForEnemyTargets();
            }

            ShortKey();

            Debug.Log(_mode);
        }

        private void AutoAtkSetting()  //모드에 따라 자동공격이 가능한지 결정
        {
            if (_mode == _Mode.MOVE || _mode == _Mode.HOLD) AutoAtk = false;
            else AutoAtk = true;
        }

        private void ShortKey() //단축키 설정
        {

            if (iUnit.isSelected())
            {
                if (Input.GetKeyDown(KeyCode.H)) _mode = _Mode.HOLD;
            }
            if (iUnit.isSelected())
            {
                if (Input.GetKeyDown(KeyCode.S)) _mode = _Mode.STOP;
            }

        }

        public void SwitchMode(_Mode UM)
        {
            _mode =
            _mode = UM;
        }

        public void SetDestinatin(Vector3 dest) //목표지점
        {
            destination = dest;
        }

        private void checkForEnemyTargets() //범위안 타겟찾음
        {

            rangeColliders = Physics.OverlapSphere(transform.position, baseStats.eyesight, UnitHandler.instance.eUnitLayer);

            //for (int i = 0; i < rangeColliders.Length;)
            //{
            //    aggerTarget = rangeColliders[i].gameObject.transform;
            //    atkUnit = aggerTarget.gameObject.GetComponent<Enemy.enemyUnit>();

            //    //hasAggero = true;
            //    //Searching = true;
            //    break;
            //}

            if (rangeColliders.Length > 0)
            {
                aggerTarget = rangeColliders[0].gameObject.transform;
                atkUnit = aggerTarget.gameObject.GetComponent<Enemy.enemyUnit>();
                search = true;
                float distance_ = Vector3.Distance(this.transform.position, atkUnit.gameObject.transform.position);

                _mode = _Mode.Attack;
                Debug.Log("유닛탐색");
                if (distance_ <= baseStats.eyesight && distance > baseStats.airattackrange)
                    MoveToAggroTarget();

                else if (distance <= baseStats.airattackrange)
                    Attack();
            }

        }



        private void MoveToAggroTarget() //타겟을 찾으면 따라감
        {
                        isAtking = false;
            if (Searching)
            {
                StartCoroutine("ReSetTargetPos");
                Debug.Log("123");
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

                        if (atkCooldown <= 0)
                        {
                            atkUnit.GetComponentInChildren<UnitStatDisplay>().TakeDamage(baseStats.airattack);
                            //aggroUnit.TakeDamage(baseStats.attack);
                            atkCooldown = baseStats.atkspeed;
                            isAtking = true;
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
                        if (atkCooldown <= 0)
                        {
                            Debug.Log("공격");
                            atkUnit.GetComponentInChildren<UnitStatDisplay>().TakeDamage(baseStats.attack);
                            //aggroUnit.TakeDamage(baseStats.attack);
                            atkCooldown = baseStats.atkspeed;
                            isAtking = true;
                        }

                    }
                }
            }



        }

        private bool Searching = true;



        IEnumerator ReSetTargetPos()
        {
            Searching = false;
            Debug.Log("코루틴");
            PF.ResetPathFind(aggerTarget.position);
            yield return new WaitForSeconds(0.5f);
            Searching = true;
        }

        public void B_UpattackCheck()
        {
            if (baseStats.bionic == false)
            {
                return;
            }

            else if (baseStats.bionic == true)
            {
                attack = baseStats.attack + (baseStats.attackplus * RTS.Player.playerManager.instance.B_atkUpCount);
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
            if (baseStats.mechanic == false || baseStats.ground == false || baseStats.air == true)
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


