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

    public GameObject weapon;
    public GameObject armor;


    void Start()
    {
        StartBtnWeapon();

        StartBtnArmor();

    }

    // Update is called once per frame
    void Update()
    {
        BtnAromorCheck();
        BtnWeaponCheck();
        WeaponUpCountChek();
        ArmorUpCountCheck();    
    }

    public void StartBtnWeapon()
    {
        if (playerManager.instance.B_atkUpCount < 1)
        {
           
            
                weapon.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
                weapon.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

                weapon.GetComponent<Button>().interactable = true;

                weapon.GetComponent<Button>().targetGraphic = weapon.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();


        }


    }
    public void StartBtnArmor()
    {
        if (playerManager.instance.B_armorUpCount < 1)
        {


            armor.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
            armor.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

            armor.GetComponent<Button>().interactable = true;

            armor.GetComponent<Button>().targetGraphic = armor.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();


        }


    }

    public void BtnWeaponCheck()
    {

       
            if (playerManager.instance.B_atkUpCount > 0)
            {
                


                    if (playerManager.instance.b_scincefacility == false)
                    {


                weapon.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
                weapon.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(true);

                weapon.GetComponent<Button>().targetGraphic = weapon.GetComponent<EnigneerungBayButton>().BtnOff.GetComponent<Image>();

                weapon.GetComponent<Button>().interactable = false;



                    }
                    else 
            {
                weapon.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
                weapon.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

                weapon.GetComponent<Button>().interactable = true;

                weapon.GetComponent<Button>().targetGraphic = weapon.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();



            }


            
              }
    }
    public void BtnAromorCheck()
    {
        if (playerManager.instance.B_armorUpCount > 0)
        {



            if (playerManager.instance.b_scincefacility == false)
            {


                armor.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
                armor.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(true);

                armor.GetComponent<Button>().targetGraphic = armor.GetComponent<EnigneerungBayButton>().BtnOff.GetComponent<Image>();

                armor.GetComponent<Button>().interactable = false;



            }
            else
            {
                armor.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(true);
                armor.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);

                armor.GetComponent<Button>().interactable = true;

                armor.GetComponent<Button>().targetGraphic = armor.GetComponent<EnigneerungBayButton>().BtnOn.GetComponent<Image>();



            }



        }



    }

    public void WeaponUpCountChek()
    {

        if (playerManager.instance.B_atkUpCount > 2)
        {
            weapon.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
            weapon.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);
            weapon.GetComponent<EnigneerungBayButton>().offBtn.SetActive(true);

            weapon.GetComponent<Button>().targetGraphic = weapon.GetComponent<EnigneerungBayButton>().offBtn.GetComponent<Image>();

            weapon.GetComponent<Button>().interactable = false;

        }

    }
    public void ArmorUpCountCheck()
    {
        if (playerManager.instance.B_armorUpCount > 2)
        {
            armor.GetComponent<EnigneerungBayButton>().BtnOn.SetActive(false);
            armor.GetComponent<EnigneerungBayButton>().BtnOff.SetActive(false);
            armor.GetComponent<EnigneerungBayButton>().offBtn.SetActive(true);

            armor.GetComponent<Button>().targetGraphic = armor.GetComponent<EnigneerungBayButton>().offBtn.GetComponent<Image>();

            armor.GetComponent<Button>().interactable = false;
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
