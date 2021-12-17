using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    public int Max;


    public enum mode
    {
        Normal,
       
        Working


    }


     public mode _Mode = mode.Normal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        
    }
    public void mineralswork()
    {
        Debug.LogError("미네랄을 캐자");
        Invoke("mineralattack", 4f);


    }

    void mineralattack()
    {

        Max -= 8;
        Debug.LogError("작업 완료");

    }


}
