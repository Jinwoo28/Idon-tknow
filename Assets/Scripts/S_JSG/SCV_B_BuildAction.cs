using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using RTS.Player;
public class SCV_B_BuildAction : MonoBehaviour
{
    public GameObject OnBtn;
    public GameObject offBtn;


    public int Btn_Num;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        commedcentercheck();
        Barrackcheck();
        Enigneerungbaycheck();

    }
    public void commedcentercheck()
    {
        
        if (playerManager.instance.b_commendcenter == false)
        {
           
            if (Btn_Num == 4||Btn_Num==5)
            {
                OnBtn.SetActive(false);
                offBtn.SetActive(true);

                gameObject.GetComponent<Button>().targetGraphic = offBtn.GetComponent<Image>();

                gameObject.GetComponent<Button>().interactable = false;

            }
          


        }
        else
        {
            if (Btn_Num == 4 || Btn_Num == 5)
            {
                OnBtn.SetActive(true);
                offBtn.SetActive(false);

                gameObject.GetComponent<Button>().interactable = true;

                gameObject.GetComponent<Button>().targetGraphic = OnBtn.GetComponent<Image>();


            }

        }


    }


    public void Barrackcheck()
    {

        if (playerManager.instance.b_barracks == false)
        {

            if (Btn_Num == 7||Btn_Num==8)
            {
                OnBtn.SetActive(false);
                offBtn.SetActive(true);

                gameObject.GetComponent<Button>().targetGraphic = offBtn.GetComponent<Image>();

                gameObject.GetComponent<Button>().interactable = false;

            }

        }
        else
        {

            if (Btn_Num == 7||Btn_Num==8)
            {

                OnBtn.SetActive(true);
                offBtn.SetActive(false);

                gameObject.GetComponent<Button>().interactable = true;

                gameObject.GetComponent<Button>().targetGraphic = OnBtn.GetComponent<Image>();

            }

        }
    }

    public void Enigneerungbaycheck()
    {

        if (playerManager.instance.b_engineeringbay == false)
        {
            if (Btn_Num == 6)
            {
                OnBtn.SetActive(false);
                offBtn.SetActive(true);

                gameObject.GetComponent<Button>().targetGraphic = offBtn.GetComponent<Image>();

                gameObject.GetComponent<Button>().interactable = false;

            }
            

        }
        else
        {
            if (Btn_Num == 6)
            {

                OnBtn.SetActive(true);
                offBtn.SetActive(false);

                gameObject.GetComponent<Button>().interactable = true;

                gameObject.GetComponent<Button>().targetGraphic = OnBtn.GetComponent<Image>();

            }

        }


    }

}
