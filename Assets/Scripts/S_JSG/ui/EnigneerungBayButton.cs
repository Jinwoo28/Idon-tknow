using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using RTS.Player;
using UI.HUD;

public class EnigneerungBayButton : MonoBehaviour
{
    public GameObject BtnOn;
    public GameObject BtnOff;
    public GameObject offBtn;


    public GameObject UpBtn;

   
    

    public int Btn_Num;


    void Start()
    {
        startBtnCheck();

    }

    // Update is called once per frame
    void Update()
    {
        BtnCheck();

        UpConuntCheck();

    }


    public void startBtnCheck()
    {
        if (Btn_Num == 1)
        {
            if (playerManager.instance.B_atkUpCount < 1)
            {


                UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
                UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

                UpBtn.GetComponent<Button>().interactable = true;

                UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();


            }

            else if (Btn_Num == 2)
            {
                if (playerManager.instance.B_armorUpCount < 1)
                {


                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

                    UpBtn.GetComponent<Button>().interactable = true;

                    UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();


                }

            }


        }


    }

    
   
    public void BtnCheck()
    {
        if (Btn_Num == 1)
        {
            if (playerManager.instance.B_atkUpCount > 0)
            {



                if (playerManager.instance.b_scincefacility == false)
                {


                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(true);

                    UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.GetComponent<Image>();

                    UpBtn.GetComponent<Button>().interactable = false;



                }
                else
                {
                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

                    UpBtn.GetComponent<Button>().interactable = true;

                    UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();



                }



            }

        }
        else if (Btn_Num == 2)
        {
            if (playerManager.instance.B_armorUpCount > 0)
            {



                if (playerManager.instance.b_scincefacility == false)
                {


                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(true);

                    UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.GetComponent<Image>();

                    UpBtn.GetComponent<Button>().interactable = false;



                }
                else
                {
                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
                    UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

                    UpBtn.GetComponent<Button>().interactable = true;

                    UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();



                }



            }

        }


    }

   public void UpConuntCheck()
    {
        if (Btn_Num == 1)
        {

            if (playerManager.instance.B_atkUpCount > 2)
            {
                UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
                UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);
                UpBtn.GetComponent<EnigneerungBayButton>().offBtn.SetActive(true);

                UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().offBtn.GetComponent<Image>();

                UpBtn.GetComponent<Button>().interactable = false;

            }

        }
        else if (Btn_Num == 2)
        {
            if (playerManager.instance.B_armorUpCount > 2)
            {
                UpBtn.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
                UpBtn.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);
                UpBtn.GetComponent<EnigneerungBayButton>().offBtn.SetActive(true);

                UpBtn.GetComponent<Button>().targetGraphic = UpBtn.GetComponent<EnigneerungBayButton>().offBtn.GetComponent<Image>();

                UpBtn.GetComponent<Button>().interactable = false;
            }

        }



    }

    

    public void B_atkupPlus()
    {
        playerManager.instance.B_atkUpCount++;


    }
    public void B_armorupPlus()
    {
        playerManager.instance.B_armorUpCount++;
    }

}
