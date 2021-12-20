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

        if (unitmode == 4)
        {
            PA.SetInteger("Move", 1);
            particle.Stop();
        }
        else if (unitmode == 5)
        {
            PA.SetInteger("Move", 2);
            particle.Play(); 
        Vector3 ParticlePos = this.transform.position-PU.rangeColliders[0].transform.position;
            Debug.Log(ParticlePos);
            ParticlePos.y = 1.5f;
            particle.transform.position = ParticlePos;


        }
        else PA.SetInteger("Move", 0);
        particle.Stop();

    }
}
