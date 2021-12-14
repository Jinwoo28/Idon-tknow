using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SetMousePoint : MonoBehaviour
{
    [SerializeField] private GameObject NomalMousePoint = null;

    [SerializeField] private Texture2D NcursorImg = null;
    [SerializeField] private Texture2D AcursorImg = null;
    [SerializeField] private Texture2D HcursorImg = null;




    void Start()
    {
        NomalMousePoint.SetActive(false);
//        NomalMousePoint.transform.localScale *= 15;
        
        Cursor.SetCursor(NcursorImg, new Vector2(13.5f, 10), CursorMode.ForceSoftware);
        Debug.Log("dd");

    }



    // Update is called once per frame
    void Update()
    {
        MousePoint_();


    }

    public void MousePoint_()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("ww");
            if (Input.GetMouseButtonDown(1))
            {
                NomalMousePoint.SetActive(false);
                NomalMousePoint.transform.position = hit.point;
                NomalMousePoint.SetActive(true);
            }

                
            if(hit.collider.CompareTag("Player_Building")|| hit.collider.CompareTag("Player_Unit"))
            {
                CursorChange(HcursorImg);
                Debug.Log("빌딩");
            }
            else if (hit.collider.CompareTag("ground"))
            {
                Debug.Log("ground");
                CursorChange(NcursorImg);
            }
            else
            {
                CursorChange(AcursorImg);
            }

        }
    }

    private void CursorChange(Texture2D T2D)
    {
        Debug.Log("커서변경");
       Cursor.SetCursor(T2D, new Vector2(13.5f, 10), CursorMode.ForceSoftware);
    }




}
