using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Player;

namespace Building.Player
{
    public class PlayerBuilding : MonoBehaviour
    {
        public BasicBuilding buildingType;



        public BuildingStatType.Base baseStats;

        public Units.UnitStatDisplay statDisplay;



        private void Start()
        {
            baseStats = buildingType.baseStats;
            statDisplay.SetStatDisplayBasicBuilding(baseStats, false);
            BuildingPlus();
            supplyplus();
        }

        public void BuildingPlus()
        {
            GameManager.instance.BuildingCheck.Add(gameObject);

            if (buildingType.name == ("Barracks"))
            {
                if (playerManager.instance.b_barracks == false)
                {
                    playerManager.instance.b_barracks = true;
                }
            }
            if (buildingType.name == ("Academy"))
            {
                if (playerManager.instance.b_academy == false)
                {
                    playerManager.instance.b_academy = true;
                }

            }
            if (buildingType.name == ("Armory"))
            {
                if (playerManager.instance.b_armory == false)
                {
                    playerManager.instance.b_armory = true;
                }
            }
            if (buildingType.name == ("CommandCenter"))
            {
                if (playerManager.instance.b_commendcenter == false)
                {
                    playerManager.instance.b_commendcenter = true;
                }

            }
            if (buildingType.name == ("CoverOPS"))
            {
                if (playerManager.instance.b_coverops == false)
                {
                    playerManager.instance.b_coverops = true;
                }
            }
            if (buildingType.name == ("EnigneerungBay"))
            {
                if (playerManager.instance.b_engineeringbay == false)
                {
                    playerManager.instance.b_engineeringbay = true;
                }
            }
            if (buildingType.name == ("Factory"))
            {
                if (playerManager.instance.b_factory == false)
                {
                    playerManager.instance.b_factory = true;
                }
            }
            if (buildingType.name == ("FactoryAddOn"))
            {
                if (playerManager.instance.b_factoryaddon == false)
                {
                    playerManager.instance.b_factoryaddon = true;
                }
            }
            if (buildingType.name == ("NuclearAddOn"))
            {
                if (playerManager.instance.b_nuclearaddon == false)
                {
                    playerManager.instance.b_nuclearaddon = true;
                }
            }
            if (buildingType.name == ("PhysicsLab"))
            {
                if (playerManager.instance.b_physicslab == false)
                {
                    playerManager.instance.b_physicslab = true;
                }
            }
            if (buildingType.name == ("ScanAddOn"))
            {
                if (playerManager.instance.b_scanaddon == false)
                {
                    playerManager.instance.b_scanaddon = true;
                }
            }
            if (buildingType.name == ("ScinceFacility"))
            {
                if (playerManager.instance.b_scincefacility == false)
                {
                    playerManager.instance.b_scincefacility = true;
                }
            }
            if (buildingType.name == ("Starport"))
            {
                if (playerManager.instance.b_starport == false)
                {
                    playerManager.instance.b_starport = true;
                }
            }
            if (buildingType.name == ("Starportaddon"))
            {
                if (playerManager.instance.b_starportaddon == false)
                {
                    playerManager.instance.b_starportaddon = true;
                }
            }
        }


        public void supplyplus()
        {
            playerManager.instance.maxsupply += baseStats.supply;   


        }


    }
}