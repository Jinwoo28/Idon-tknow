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

        [SerializeField] private ParticleSystem particle = null;


        private Vector3 destination;


        public float attack;
        public float airattack;
        public float atkspeed;
        public float speed;
        public float armor;
        public float atkRange;
        public float atkUpPlus;
        public float airatkRange;
        public int DropCount;

        public float eyesight;





        private bool AutoAtk = false;   //�ڵ������� �������� ����
        public bool isAtking = false;   //���� ���������� ����
        private bool search = true;

        Interactables.IUnit iUnit = null;

        private PathFinding PF = null;
        public _Mode _mode { get; set; }

        private void Awake()
        {
            Mcamera = Camera.main;


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
            airatkRange = baseStats.airattackrange;

            eyesight = baseStats.eyesight;
        }
        private void Start() {
            statDisplay.SetStatatDisplayUnit(baseStats, true);
            RTS.Player.playerManager.instance.supply += baseStats.supply;

            iUnit = GetComponent<Interactables.IUnit>();
        }

        void Update()
        {
            if (atkCooldown >= -1)
                atkCooldown -= Time.deltaTime;

                AutoAtkSetting();
                checkForEnemyTargets();

            if (_mode != _Mode.MOVE && _mode != _Mode.HOLD)
            {
                targetrange();
            }

            ShortKey();

            Debug.Log(_mode);
            Debug.Log("���� ���� / " + isAtking);

            if (!isAtking) {
                if (particle != null)
                    particle.Stop();
            }
        }

        private void AutoAtkSetting()  //��忡 ���� �ڵ������� �������� ����
        {
            if (_mode == _Mode.MOVE || _mode == _Mode.HOLD) AutoAtk = false;
            else AutoAtk = true;
        }

        private void ShortKey() //����Ű ����
        {

            if (iUnit.isSelected())
            {
                if (Input.GetKeyDown(KeyCode.H)) _mode = _Mode.HOLD;
                isAtking = false;
            }
            if (iUnit.isSelected())
            {
                if (Input.GetKeyDown(KeyCode.S)) _mode = _Mode.STOP;
                isAtking = false;
            }

        }

        public void SwitchMode(_Mode UM)
        {
            _mode = UM;
        }



        public void SetDestinatin(Vector3 dest) //��ǥ����
        {
            destination = dest;
        }

        private void checkForEnemyTargets() //������ Ÿ��ã��
        {
            if (atkUnit == null)
            {
                rangeColliders = Physics.OverlapSphere(transform.position, baseStats.eyesight, UnitHandler.instance.eUnitLayer);



                if (rangeColliders.Length > 0)
                {
                    for (int i = 0; rangeColliders[i]; i++)
                    {
                        if (rangeColliders[i].gameObject.GetComponent<Enemy.enemyUnit>().baseStats.ground == true)
                        {
                            if (atkRange > 0)
                            {
                                aggerTarget = rangeColliders[i].gameObject.transform;
                                atkUnit = aggerTarget.gameObject.GetComponent<Enemy.enemyUnit>();
                                Searching = true;
                                distance = Vector3.Distance(this.transform.position, atkUnit.gameObject.transform.position);
                                break;
                            }



                        }
                        else
                        {
                            if (airatkRange > 0)
                            {

                                aggerTarget = rangeColliders[i].gameObject.transform;
                                atkUnit = aggerTarget.gameObject.GetComponent<Enemy.enemyUnit>();
                                Searching = true;
                                distance = Vector3.Distance(this.transform.position, atkUnit.gameObject.transform.position);
                                break;

                            }
                        }

                    }

                    Debug.Log("����Ž��");
                }
            else atkUnit = null;
            }
        }


            public void targetrange() {

            _mode = _Mode.Attack;

            if (atkUnit!=null)
            {
                if (atkUnit.baseStats.ground == true)
                {
                    if (distance < atkRange )
                    {
                        Debug.Log("���� ����");
                        PF.StopPathFind();
                        Attack();
                    }
                    else if (distance >= atkRange )
                    {
                        Debug.Log("�Ѿư���");
                        MoveToAggroTarget();
                        this.transform.forward = atkUnit.gameObject.transform.position;
                    }
                }
                else { 

                    if (distance < airatkRange)
                    {
                        Debug.Log("���� ����2 ");
                        PF.StopPathFind();
                        Attack();
                    }
                    else if(distance >= airatkRange)
                    {
                      
                        MoveToAggroTarget();
                        this.transform.forward = atkUnit.gameObject.transform.position;
                    }
                }


                //if (distance <= baseStats.airattackrange)
                //{
                //    Attack();
                //    this.transform.forward = rangeColliders[0].gameObject.transform.position;
                //    PF.StopFathPinding();
                //}
            }
            }

        
    




            private void MoveToAggroTarget() //Ÿ���� ã���� ����
        {
            isAtking = false;
            if (atkUnit != null)
            {
                if (search)
                {
                    StartCoroutine("ReSetTargetPos");
                    Debug.Log("123");
                }
            }
            
        }

        private void Attack()
        {
            if (atkUnit != null)
            {
                if (atkUnit.baseStats.ground == false)
                {
                    if (baseStats.airattack <= 0||baseStats.airattackrange<=0)
                    {
                        return;
                    }
                    else
                    {

                        if (atkCooldown <= 0&&baseStats.airattackrange> distance)
                        {
                            atkUnit.GetComponentInChildren<enemyStatDisplay>().TakeDamage(baseStats.airattack);
                            //aggroUnit.TakeDamage(baseStats.attack);
                            atkCooldown = baseStats.atkspeed;
                            isAtking = true;

                            if (particle != null)
                            {
                                particle.Play();
                                Vector3 ParticlePos = new Vector3(
                                    Mathf.Abs(this.transform.position.x - rangeColliders[0].transform.position.x),
                                     Mathf.Abs(this.transform.position.y - rangeColliders[0].transform.position.y),
                                      Mathf.Abs(this.transform.position.z - rangeColliders[0].transform.position.z));
                                ParticlePos.y = 1.5f;
                                particle.transform.position = this.transform.position + ParticlePos;

                            }
                        }

                    }
                }
                else
                {
                    if (baseStats.attack <= 0||baseStats.atkRange<=0)
                    {
                        return;
                    }
                    else
                    {
                        if (atkCooldown <= 0&&atkRange>distance)
                        {
                            Debug.Log("����");
                            atkUnit.GetComponentInChildren<enemyStatDisplay>().TakeDamage(baseStats.attack);
                            atkCooldown = baseStats.atkspeed;
                            isAtking = true;

                            if(particle != null)
                            {
                                particle.Play();
                                Vector3 ParticlePos = new Vector3(
                                    Mathf.Abs(this.transform.position.x - rangeColliders[0].transform.position.x),
                                     Mathf.Abs(this.transform.position.y -rangeColliders[0].transform.position.y),
                                      Mathf.Abs(this.transform.position.z - rangeColliders[0].transform.position.z));
                                ParticlePos.y = 1.5f;
                                particle.transform.position = this.transform.position + ParticlePos;

                            }

                        }

                    }
                }
            }



        }

        private bool Searching = true;



        IEnumerator ReSetTargetPos()
        {
            search = false;
            Debug.Log("�ڷ�ƾ");
            PF.ResetPathFind(aggerTarget.position);
            yield return new WaitForSeconds(0.5f);
            search =true;
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


