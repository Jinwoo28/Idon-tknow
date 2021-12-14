using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ddddd : MonoBehaviour
{
 public   GameObject Mouse = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {

            if (Input.GetMouseButtonDown(1))
            {
               GameObject GO =  Instantiate(Mouse, hit.point, Quaternion.identity);
                GO.transform.localScale *= 20;

            }
        }
    }
}
