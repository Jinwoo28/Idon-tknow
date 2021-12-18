using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerals : MonoBehaviour
{
    public int Max;

    Units.Player.scv _scv = null;
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

   public void mineralattack()
    {

        Max -= 8;
        Debug.LogError("작업 완료");
        if (Max <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<Units.Player.PlayerUnit>().unitType.name == "SCV")
        {

            if (other.gameObject.GetComponent<Units.Player.scv>().Min_Working == true)
            {

                other.gameObject.GetComponent<Units.Player.scv>().Min_Working = false;

                other.gameObject.GetComponent<Units.Player.scv>().canslework();
            }

        }
    }
            

}
