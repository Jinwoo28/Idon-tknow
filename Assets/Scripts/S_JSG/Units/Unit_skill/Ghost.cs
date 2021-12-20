using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Player;

namespace Units.Player
{
    public class Ghost : MonoBehaviour
    {
        private Animator PA = null;
        private Units.Player.PlayerUnit PU = null;

        public GameObject ghost;
        void Start()
        {
            if (playerManager.instance.GhosteyeCheck == false)
            {
                ghost.GetComponent<PlayerUnit>().baseStats.eyesight = 9;
            }
            else
            {
                ghost.GetComponent<PlayerUnit>().baseStats.eyesight = 11;
            }

            if (playerManager.instance.GhosMpCheck == false)
            {
                ghost.GetComponent<PlayerUnit>().baseStats.maxmp = 200;
                ghost.GetComponent<PlayerUnit>().baseStats.mp = 50;

            }
            else
            {
                ghost.GetComponent<PlayerUnit>().baseStats.maxmp = 250;
                ghost.GetComponent<PlayerUnit>().baseStats.mp = 62.5f;

            }

            PA = GetComponent<Animator>();
            PU = GetComponent<Units.Player.PlayerUnit>();

        }

        // Update is called once per frame
        void Update()
        {
            int unitmode = (int)PU._mode;

            if (unitmode == 4)
            {
                PA.SetInteger("Move", 1);
            }
            else if (unitmode == 5)
            {
                PA.SetInteger("Move", 2);
            }
            else PA.SetInteger("Move", 0);

        }
        public void mpup()
        {
            playerManager.instance.GhosMpCheck = true;

            ghost.GetComponent<PlayerUnit>().baseStats.maxmp = 250;



        }
        public void eyesightup()
        {
            playerManager.instance.GhosteyeCheck = true;

            ghost.GetComponent<PlayerUnit>().baseStats.eyesight = 11;
           

        }


    }
}
