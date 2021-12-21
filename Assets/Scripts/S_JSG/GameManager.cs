using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RTS.Player
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;


        public List<GameObject> BuildingCheck = new List<GameObject>();

        public List<GameObject> EnemyCheck = new List<GameObject>();

        public List<Transform> center = new List<Transform>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }

        public void buildingnamecheck(string objectname)
        {
            bool checkname = false;

            for (int i = 0; i < BuildingCheck.Count; i++)
            {



                if (objectname == BuildingCheck[i].GetComponent<Building.Player.PlayerBuilding>().buildingType.name)
                {
                    checkname = true;
                    Debug.Log("Á¸ÀçÇÔ");
                    break;
                }


            }

            if (checkname == false)
            {
                if (objectname == ("Barracks"))
                {


                    playerManager.instance.b_barracks = false;

                }
                if (objectname == ("Academy"))
                {


                    playerManager.instance.b_academy = false;


                }
                if (objectname == ("Armory"))
                {


                    playerManager.instance.b_armory = false;

                }
                if (objectname == ("CommandCenter"))
                {


                    playerManager.instance.b_commendcenter = false;


                }
                if (objectname == ("CoverOPS"))
                {


                    playerManager.instance.b_coverops = false;

                }
                if (objectname == ("EnigneerungBay"))
                {


                    playerManager.instance.b_engineeringbay = false;

                }
                if (objectname == ("Factory"))
                {

                    playerManager.instance.b_factory = false;

                }
                if (objectname == ("FactoryAddOn"))
                {

                    playerManager.instance.b_factoryaddon = false;


                }
                if (objectname == ("NuclearAddOn"))
                {


                    playerManager.instance.b_nuclearaddon = false;

                }
                if (objectname == ("PhysicsLab"))
                {

                    playerManager.instance.b_physicslab = false;

                }
                if (objectname == ("ScanAddOn"))
                {


                    playerManager.instance.b_scanaddon = false;

                }
                if (objectname == ("ScinceFacility"))
                {

                    playerManager.instance.b_scincefacility = false;

                }
                if (objectname == ("Starport"))
                {

                    playerManager.instance.b_starport = false;

                }
                if (objectname == ("Starportaddon"))
                {

                    playerManager.instance.b_starportaddon = false;

                }

            }


        }

        public void WinCheck()
        {

            if (EnemyCheck.Count == 0)
            {

                //½Â¸®¾À 


            }


        }
        public void loseCheck()
        {
            if (BuildingCheck.Count == 0)
            {
                //ÆÐ¹è¾À

            }




        }
    }
}

