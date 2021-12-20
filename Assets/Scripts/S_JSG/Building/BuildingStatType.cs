using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    public class BuildingStatType : ScriptableObject
    {
        [System.Serializable]
        public class Base
        {
            public int mineral, gas, health;
                public float armor, eyesight;

            public int supply;


            public enum size
            {
                small,
                normal,
                big
            }

            public size building_size;

            public bool ground;

            public bool mechanic;

            public bool building;

            public bool spawn;

        }
    }
}
