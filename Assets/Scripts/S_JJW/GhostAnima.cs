using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnima : MonoBehaviour
{
    private Animator PA = null;
    private Units.Player.PlayerUnit PU = null;

    private int unitmode = 0;
    void Start()
    {
        PA = GetComponent<Animator>();
        PU = GetComponent<Units.Player.PlayerUnit>();
    }

    // Update is called once per frame
    void Update()
    {
        unitmode = (int)PU._mode;

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
}
