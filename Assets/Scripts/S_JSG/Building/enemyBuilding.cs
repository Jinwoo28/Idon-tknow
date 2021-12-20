using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building.Enemy
{
    public class enemyBuilding : MonoBehaviour
    {

        public BasicBuilding buildingType;



        public BuildingStatType.Base baseStats;

        public Units.UnitStatDisplay statDisplay;

        void Start()
        {

            baseStats = buildingType.baseStats;
            statDisplay.SetStatDisplayBasicBuilding(baseStats, false);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}