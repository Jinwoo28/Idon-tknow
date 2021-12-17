using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using RTS.Player;
public class SCV_A_BuildAction : MonoBehaviour
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
        BarrakCheck();
        FactoryCheck();
        starportcheck();
        
    }

    public void BarrakCheck()
    {
        if (playerManager.instance.b_barracks == false)
        {

            if (Btn_Num == 1)
            {
                OnBtn.SetActive(false);
                offBtn.SetActive(true);

                gameObject.GetComponent<Button>().targetGraphic = offBtn.GetComponent<Image>();

                gameObject.GetComponent<Button>().interactable = false;



            }


        }
        else
        {
            if (Btn_Num == 1)
            {
                OnBtn.SetActive(true);
                offBtn.SetActive(false);

                gameObject.GetComponent<Button>().interactable = true;

                gameObject.GetComponent<Button>().targetGraphic = OnBtn.GetComponent<Image>();

            }

        }


    }

    public void FactoryCheck()
    {
        if (playerManager.instance.b_factory == false)
        {

            if (Btn_Num == 2 || Btn_Num == 4)
            {
                OnBtn.SetActive(false);
                offBtn.SetActive(true);

                gameObject.GetComponent<Button>().targetGraphic = offBtn.GetComponent<Image>();

                gameObject.GetComponent<Button>().interactable = false;



            }

        }
        else
        {
            if (Btn_Num == 2 || Btn_Num == 4)
            {
                OnBtn.SetActive(true);
                offBtn.SetActive(false);

                gameObject.GetComponent<Button>().interactable = true;

                gameObject.GetComponent<Button>().targetGraphic = OnBtn.GetComponent<Image>();



            }

        }

    }

    public void starportcheck()
    {

        if (playerManager.instance.b_starport == false)
        {

            if (Btn_Num == 3)
            {
                OnBtn.SetActive(false);
                offBtn.SetActive(true);

                gameObject.GetComponent<Button>().targetGraphic = offBtn.GetComponent<Image>();

                gameObject.GetComponent<Button>().interactable = false;




            }


        }
        else
        {

            if (Btn_Num == 3)
            {
                OnBtn.SetActive(true);
                offBtn.SetActive(false);

                gameObject.GetComponent<Button>().interactable = true;

                gameObject.GetComponent<Button>().targetGraphic = OnBtn.GetComponent<Image>();

            }

        }

    }
}
