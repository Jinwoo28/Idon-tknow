using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarineAnima : MonoBehaviour
{
    private Animator PA = null;
    private Units.Player.PlayerUnit PU = null;

    [SerializeField] private ParticleSystem particle = null;

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

        AnimaPlay();
    }

    public void AnimaPlay()
    {
        if (unitmode == 4)
        {
            PA.SetInteger("Move", 1);

        }
        else if (unitmode == 5 && PU.isAtking)
        {
            PA.SetInteger("Move", 2);
        }
        else PA.SetInteger("Move", 0);


    }
}
