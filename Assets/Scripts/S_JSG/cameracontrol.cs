using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    public float camspeed;
    public float scrolspeed;
    public float miny = 20f;
    public float maxy = 120f;

    public float BorderThickness = 10f;


    public Vector2 limit;

    [SerializeField] private Camera MiniCam = null;
    [SerializeField] LayerMask mask;

    public GameObject DDD;

    public GameObject DebugSp = null;


    void Start()
    {

    }


    void Update()
    {
        MouseMove();

        CamPosSet();
       // MoveToMinimapPos();
    }

    public void MouseMove()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow) || Input.mousePosition.y >= Screen.height - BorderThickness)
        {
            pos.z += camspeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.mousePosition.y <= BorderThickness)
        {
            pos.z -= camspeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.mousePosition.x >= Screen.width - BorderThickness)
        {
            pos.x += camspeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.mousePosition.x <= BorderThickness)
        {
            pos.x -= camspeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrolspeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, 0, 120);
        pos.y = 3f;
        pos.z = Mathf.Clamp(pos.z, 0, 120);

        transform.position = pos;
    }


    public void MoveToMinimapPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
    
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                var hitpoint = hit.point;

                Ray sconRay = MiniCam.ViewportPointToRay(hitpoint);

                RaycastHit worldHit; ;
                if (Physics.Raycast(sconRay, out worldHit, MiniCam.farClipPlane))
                {
                    Vector3 Pos = new Vector3(worldHit.point.x, this.transform.position.y, worldHit.point.z);
                    this.transform.position = Pos;
                    Debug.Log("2222");
                }
            }
   
        }
    }

    private void CamPosSet()
    {
        
        Vector3 thisPos = this.transform.position;

        Ray ray = MiniCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit))
        {
            if (Input.GetMouseButton(0))
            {
                thisPos.x = hit.point.x;
                thisPos.z = hit.point.z;
                Debug.Log(hit.transform.name + " / " + hit.point);

                //Instantiate(DDD, thisPos, Quaternion.identity);

                
                this.transform.position = thisPos * (MiniCam.orthographicSize / 100f);

                Debug.DrawRay(MiniCam.ScreenToWorldPoint(Input.mousePosition), MiniCam.transform.forward * 100f);
            }
        }
        //thisPos.y = 10;
        //DebugSp.transform.position = thisPos;
    }
}
