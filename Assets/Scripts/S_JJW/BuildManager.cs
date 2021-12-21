using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Craft  // 생성할 건물들을 분류할 클래스
{
        

    public string craftname; //건물 이름
    public GameObject previewCraft; //미리보기 프리펩
    public GameObject BuildCraft; // 실제 지어질 프리펩
    

}
namespace RTS.Player
{
    public class BuildManager : MonoBehaviour
    {

        public static BuildManager instance = null;

        [SerializeField] private Craft[] craft = null;  //직렬화를 통해 인스펙터창에서 관리하기 위한 변수

        private GameObject PreviewPrefab = null;    //Craft를 담을 변수와 미리보기에 사용할 변수 선언
        private GameObject InsPrefab = null;    //생성할 건물

        public bool isActivatePreview = false; //Preview가 만들어졌는지 확인할 bool값 변수

        //
        private RaycastHit hit;
        private Vector3 _location;

        private Vector3 buildPos;

        public bool B_buildingcheck=false;
        public bool A_buildingcheck = false;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }

        }
        private void Start()
        {
            
        }
        private void Update()
        {

            if (!isActivatePreview)
            {
                if (B_buildingcheck == true)
                {
                    if (Input.GetKeyDown(KeyCode.C)) SlotClick(0, 400);
                    if (Input.GetKeyDown(KeyCode.S)) SlotClick(1, 100);
                    if (Input.GetKeyDown(KeyCode.R)) SlotClick(2, 100);
                    if (Input.GetKeyDown(KeyCode.B)) SlotClick(3, 150);
                    if (Input.GetKeyDown(KeyCode.E)) SlotClick(4, 125);
                    if (Input.GetKeyDown(KeyCode.T)) SlotClick(5, 75);
                    if (Input.GetKeyDown(KeyCode.A)) SlotClick(6, 150);
                    if (Input.GetKeyDown(KeyCode.U)) SlotClick(7, 100);
                }
                    if (A_buildingcheck == true)
                    {
                        if (Input.GetKeyDown(KeyCode.F)) SlotClick(8, 200);
                        if (Input.GetKeyDown(KeyCode.S)) SlotClick(9, 150);
                        if (Input.GetKeyDown(KeyCode.I)) SlotClick(10, 100);
                        if (Input.GetKeyDown(KeyCode.A)) SlotClick(11, 100);
                    }


                
               
            }

            if (isActivatePreview)
            {
                int layerMask = (1 << LayerMask.NameToLayer("ground")) + (1 << LayerMask.NameToLayer("Sea"));   //충돌검사를 할 레이어

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
                {
                    //   Debug.Log(hit.point);

                    Debug.Log("위치이동");
                    _location = hit.point;
                    _location.y += 0.1f;

                    buildPos = new Vector3((int)_location.x, hit.point.y, (int)_location.z);
                    PreviewPrefab.transform.position = buildPos;

                }
            }

            if (PreviewPrefab != null && PreviewPrefab.GetComponentInChildren<Preview>().GetBuildable())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(InsPrefab, buildPos, Quaternion.identity);
                    Destroy(PreviewPrefab);
                    isActivatePreview = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape) && PreviewPrefab != null)
            {
                Destroy(PreviewPrefab);
                isActivatePreview = false;
            }
        }

        public void DDD()
        {

        }


        public void SlotClick(int _SlotNumber,int Minerals)
        {
            
            
                isActivatePreview = false;
                InsPrefab = craft[_SlotNumber].BuildCraft;
          
      
            if (Minerals > playerManager.instance.Minerals)
            {

                Debug.LogError("미네랄 부족");
                return;
            }
            else
            {
                playerManager.instance.Minerals -= Minerals;
                PreviewPrefab = Instantiate(craft[_SlotNumber].previewCraft);
                Debug.Log("프리뷰 : " + isActivatePreview);
                isActivatePreview = true;
                Debug.Log("프리뷰2 : " + isActivatePreview);
            }
            
            
        }


    }






}