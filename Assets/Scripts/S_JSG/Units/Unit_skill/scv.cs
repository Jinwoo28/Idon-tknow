using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units.Player
{
    public class scv : MonoBehaviour
    {
        public GameObject _scv_;

        public Collider[] rangeCollider;
        
        public LayerMask Minlayer;

        public GameObject MineralsTarget;
        enum mode
        {
            Normal,
            Minerals,
            GAS

        }

        mode _Mode = mode.Normal;


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void changMinerals()
        {
            _Mode = mode.Minerals;

        }

        public void scvAction()
        {
            switch (_Mode)
            {

                case mode.Minerals:

                    //¹Ì³×¶ö ÀÌµ¿






                    break;




            }



        }

       public void mineralscheck()
        {
           
            rangeCollider = Physics.OverlapSphere(transform.position, _scv_.GetComponent<PlayerUnit>().baseStats.eyesight, 25);

            for (int i = 0; i < rangeCollider.Length; i++)
            {
                if (rangeCollider[i].GetComponent<Minerals>()._Mode == Minerals.mode.Normal)
                {
                    MineralsTarget = rangeCollider[i].gameObject;

                    break;
                    

                }

            }



        }
        public void mineralattack()
        {

            
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            
            if (collision.gameObject.layer == 25)
            {
                mineralattack();
                {

                    collision.gameObject.GetComponent<Minerals>().mineralswork();

                }


            }

        }
    }
}