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

        public GameObject HandMinerals;

        public bool Min_Working;
        public bool MinFinish;
        public enum mode
        {
            Normal,
            Minerals,
            GAS

        }

        public mode _Mode = mode.Normal;


        void Start()
        {
            
            _Mode = mode.Normal;
        HandMinerals.SetActive(false);
            Min_Working = false;
            MinFinish = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void changMinerals()
        {
            _Mode = mode.Minerals;

        }
        public void changNormals()
        {
            _Mode = mode.Normal;
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
        private void OnTriggerEnter(Collider other)
        {

            
            if (other.gameObject.layer == 25)
            {

                if (_Mode == mode.Minerals)
                {
                    Debug.Log("¹Ì³×¶ö ºÎµúÈû" + other.gameObject.layer);
                    StartCoroutine("Work", other);
                }


            }
            if (other.gameObject.layer == 3) {
                Debug.Log(" °Ç¹° ÅÍÄ¡");
                if (other.gameObject.gameObject.GetComponent<Building.Player.PlayerBuilding>().buildingType.name == "CommandCenter")
                {
                    if (MinFinish == true)
                    {
                        HandMinerals.SetActive(false);
                        MinFinish = false;
                        RTS.Player.playerManager.instance.Minerals += 8;

                    }


                }
                    }

        }

        public IEnumerator Work(Collider objt)
        {

            Debug.Log("ÀÛ¾÷Áß");
            Min_Working = true;

            yield return new WaitForSeconds(4f);
            workFinish(objt);

        }
        public void workFinish(Collider objt)
        {
            objt.GetComponent<Minerals>().mineralattack();
            HandMinerals.SetActive(true);
            Min_Working = false;
            MinFinish = true;

        }
        public void canslework()
        {
            StopCoroutine("Work");
            Debug.Log("Ãë¼Ò");
            _Mode = mode.Normal;

        }
        //private void tr
        //{
            
        //    if (collision.gameObject.layer == 25)
        //    {
        //        Debug.Log("¹Ì³×¶ö ºÎµúÈû" + collision.gameObject.layer);

        //        mineralattack();
        //        {

        //            collision.gameObject.GetComponent<Minerals>().mineralswork();

        //        }


        //    }

        //}
        public bool MineralsWorking()
        {


            return Min_Working;
        }
    }
}