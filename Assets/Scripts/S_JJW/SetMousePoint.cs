using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SetMousePoint : MonoBehaviour
{
    [SerializeField] private GameObject NomalMousePoint = null;
    [SerializeField] private GameObject AomalMousePoint = null;

    [SerializeField] private Texture2D NcursorImg = null;
    [SerializeField] private Texture2D AcursorImg = null;
    [SerializeField] private Texture2D HcursorImg = null;


    private bool isAtk = false;

    // 테스트 확인용 주석 
    void Start()
    {
        NomalMousePoint.SetActive(false);
        AomalMousePoint.SetActive(false);
        //        NomalMousePoint.transform.localScale *= 15;

        Cursor.SetCursor(NcursorImg, new Vector2(13.5f, 10), CursorMode.ForceSoftware);
      //  Debug.Log("dd");

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

       // int layerMask = (1 << LayerMask.NameToLayer("ground")) + (1 << LayerMask.NameToLayer("Sea"));
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
             if (Input.GetMouseButtonDown(1))
            {
                NomalMousePoint.SetActive(false);
                NomalMousePoint.transform.position = hit.point;
                NomalMousePoint.SetActive(true);
                isAtk = false;
            }

            if (Input.GetMouseButtonDown(0) && isAtk)
            {
                AomalMousePoint.SetActive(false);
                AomalMousePoint.transform.position = hit.point;
                AomalMousePoint.SetActive(true);
                isAtk = false;
            }



            if (Input.GetKeyDown(KeyCode.A)) isAtk = true;

            if (isAtk)
            {
                CursorChange(AcursorImg);
            }

            else
            {
                if (hit.collider.CompareTag("Player_Building") || hit.collider.CompareTag("Player_Unit"))
                {
                    CursorChange(HcursorImg);
                }
                else if (hit.collider.CompareTag("ground"))
                {
                  //  Debug.Log("ground");
                    CursorChange(NcursorImg);
                }
            }
        

        }
    }

    private void CursorChange(Texture2D T2D)
    {
       // Debug.Log("커서변경");
       Cursor.SetCursor(T2D, new Vector2(13.5f, 10), CursorMode.ForceSoftware);
    }




}
