using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Building {
    public class MissileTurret : MonoBehaviour
    {
        public GameObject missileturret;

        private float attack = 20f;
        private float atkSpeed = 1.5f;
        private float atkRange = 7f;
        private float atkCooldown;

        public bool enemy;
        

        public float distance; //private

        public Collider[] rangeColliders;//private

        public enum atk_type
        {
            normal,
            vibration,
            blast
        }

        public atk_type air_type;
        //public Transform aggerTarget; //private
        private Units.Enemy.enemyUnit atkUnit;

        private Units.Player.PlayerUnit atkPlayer;


        void Start()
        {
            

        }

        // Update is called once per frame
        void Update()
        {
            if (atkCooldown>=-1)
            atkCooldown -= Time.deltaTime;

            if (enemy == false)
            {
                checkForEnemyTargets();
                if (atkUnit == true)
                {
                    RangeCheck();
                    turretAttack();
                }
            }
            else
            {
                checkForPlayerTargets();
                if (atkPlayer == true)
                {
                    P_RangeCheck();
                    P_turretAttack();

                }
            }
            
           

            

        }

        private void checkForEnemyTargets() //¹üÀ§¾È Å¸°ÙÃ£À½
        {

            rangeColliders = Physics.OverlapSphere(transform.position, missileturret.GetComponent <Player.PlayerBuilding>().baseStats.eyesight, Units.UnitHandler.instance.eUnitLayer);

            if (rangeColliders.Length > 0)
            {
                for (int i = 0; i < rangeColliders.Length;i++)
                {
                   
                        if (rangeColliders[i].gameObject.GetComponent<Units.Enemy.enemyUnit>().baseStats.air == true)
                        {


                            atkUnit = rangeColliders[i].gameObject.GetComponent<Units.Enemy.enemyUnit>();


                            break;

                        }
                    
                }
            }
           
        }
        private void checkForPlayerTargets()
        {

            rangeColliders = Physics.OverlapSphere(transform.position, missileturret.GetComponent<Enemy.enemyBuilding>().baseStats.eyesight, Units.UnitHandler.instance.pUnitLayer);

            if (rangeColliders.Length > 0)
            {
                for (int i = 0; i < rangeColliders.Length; i++)
                {
                    if (rangeColliders[i].gameObject.GetComponent<Units.Player.PlayerUnit>().baseStats.air == true)
                    {


                        atkPlayer = rangeColliders[i].gameObject.GetComponent<Units.Player.PlayerUnit>();


                        break;

                    }
                }
            }


        }
        private void turretAttack()
        {
           
            if (distance<=atkRange&&atkCooldown<=0)
            {

                atkUnit.GetComponentInChildren<Units.enemyStatDisplay>().TakeDamage(attack);
                atkCooldown = atkSpeed;
                Debug.Log("ÅÍ·¿ °ø°Ý");
            }


        }

        private void RangeCheck()
        {
            distance = Vector3.Distance(atkUnit.transform.position, transform.position);


            if (distance >= 15)
                atkUnit = null;
        }
        private void P_turretAttack()
        {

            if (distance <= atkRange && atkCooldown <= 0)
            {

                atkPlayer.GetComponentInChildren<Units.UnitStatDisplay>().TakeDamage(attack);
                atkCooldown = atkSpeed;
                Debug.Log("ÅÍ·¿ °ø°Ý");
            }


        }

        private void P_RangeCheck()
        {
            distance = Vector3.Distance(atkPlayer.transform.position, transform.position);


            if (distance >= 15)
                atkPlayer = null;
        }

    }
}
