using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using RTS.Player;
public class ArmoryButton : MonoBehaviour
{
    public GameObject BtnOn;
    public GameObject BtnOff;
    public GameObject offBtn;

    public GameObject UPBtn;

   
    public int Btn_Num;
    void Start()
    {
        StartBtnCheck();
    }

    // Update is called once per frame
    void Update()
    {
        BtnCheck();

        UpCountChek();

    }
    public void StartBtnCheck()
    {

        if (Btn_Num == 1)
        {
            if (playerManager.instance.M_GroundatkUpCount < 1)
            {


                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);


                UPBtn.GetComponent<Button>().interactable = true;

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


            }
        }
        else if (Btn_Num == 2)
        {
            if (playerManager.instance.M_GroundarmorUpCount < 1)
            {


                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                UPBtn.GetComponent<Button>().interactable = true;

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


            }
        }
        else if (Btn_Num == 3)
        {
            if (playerManager.instance.M_AiratkUpCount < 1)
            {


                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                UPBtn.GetComponent<Button>().interactable = true;

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


            }
        }
        else if (Btn_Num == 4)
        {
            if (playerManager.instance.M_AirarmorUpCount < 1)
            {


                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                UPBtn.GetComponent<Button>().interactable = true;

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


            }
        }

    }
    //public void StartBtnWeapon()
    //{
    //    if (playerManager.instance.M_GroundatkUpCount < 1)
    //    {


    //        G_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //        G_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        G_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(false);


    //        G_weapon.GetComponent<Button>().interactable = true;

    //        G_weapon.GetComponent<Button>().targetGraphic = G_weapon.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


    //    }


    //}
    //public void StartBtnArmor()
    //{
    //    if (playerManager.instance.M_GroundarmorUpCount < 1)
    //    {


    //        G_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //        G_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        G_armor.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //        G_armor.GetComponent<Button>().interactable = true;

    //        G_armor.GetComponent<Button>().targetGraphic = G_armor.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


    //    }


    //}
    //public void StartBtnAirWeapon()
    //{
    //    if (playerManager.instance.M_AiratkUpCount < 1)
    //    {


    //        A_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //        A_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        A_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //        A_weapon.GetComponent<Button>().interactable = true;

    //        A_weapon.GetComponent<Button>().targetGraphic = A_weapon.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


    //    }


    //}
    //public void StartBtnAirArmor()
    //{
    //    if (playerManager.instance.M_AirarmorUpCount < 1)
    //    {


    //        A_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //        A_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        A_armor.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //        A_armor.GetComponent<Button>().interactable = true;

    //        A_armor.GetComponent<Button>().targetGraphic = A_armor.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();


    //    }


    //}



    public void BtnCheck()
    {
        if (Btn_Num == 1)
        {
            if (playerManager.instance.M_GroundatkUpCount > 0)
            {



                if (playerManager.instance.b_scincefacility == false)
                {


                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

                    UPBtn.GetComponent<Button>().interactable = false;



                }
                else
                {
                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().interactable = true;

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



                }
            }

        }

        else if (Btn_Num == 2)
        {
            if (playerManager.instance.M_GroundarmorUpCount > 0)
            {



                if (playerManager.instance.b_scincefacility == false)
                {


                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

                    UPBtn.GetComponent<Button>().interactable = false;



                }
                else
                {
                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().interactable = true;

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



                }

            }
        }

        else if (Btn_Num == 3)
        {

            if (playerManager.instance.M_AiratkUpCount > 0)
            {



                if (playerManager.instance.b_scincefacility == false)
                {


                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

                    UPBtn.GetComponent<Button>().interactable = false;



                }
                else
                {
                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().interactable = true;

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



                }



            }
        }

        else if (Btn_Num == 4)
        {
            if (playerManager.instance.M_AirarmorUpCount > 0)
            {



                if (playerManager.instance.b_scincefacility == false)
                {


                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

                    UPBtn.GetComponent<Button>().interactable = false;



                }
                else
                {
                    UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
                    UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                    UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(false);

                    UPBtn.GetComponent<Button>().interactable = true;

                    UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



                }



            }

        }


    }
    //public void BtnWeaponCheck()
    //{


    //    if (playerManager.instance.B_atkUpCount > 0)
    //    {



    //        if (playerManager.instance.b_scincefacility == false)
    //        {


    //            G_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //            G_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
    //            G_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            G_weapon.GetComponent<Button>().targetGraphic = G_weapon.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

    //            G_weapon.GetComponent<Button>().interactable = false;



    //        }
    //        else
    //        {
    //            G_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //            G_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //            G_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            G_weapon.GetComponent<Button>().interactable = true;

    //            G_weapon.GetComponent<Button>().targetGraphic = G_weapon.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



    //        }



    //    }
    //}
    //public void BtnAromorCheck()
    //{
    //    if (playerManager.instance.B_armorUpCount > 0)
    //    {



    //        if (playerManager.instance.b_scincefacility == false)
    //        {


    //            G_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //            G_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
    //            G_armor.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            G_armor.GetComponent<Button>().targetGraphic = G_armor.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

    //            G_armor.GetComponent<Button>().interactable = false;



    //        }
    //        else
    //        {
    //            G_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //            G_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //            G_armor.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            G_armor.GetComponent<Button>().interactable = true;

    //            G_armor.GetComponent<Button>().targetGraphic = G_armor.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



    //        }



    //    }



    //}
    //public void BtAirnWeaponCheck()
    //{


    //    if (playerManager.instance.B_atkUpCount > 0)
    //    {



    //        if (playerManager.instance.b_scincefacility == false)
    //        {


    //            A_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //            A_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
    //            A_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            A_weapon.GetComponent<Button>().targetGraphic = A_weapon.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

    //            A_weapon.GetComponent<Button>().interactable = false;



    //        }
    //        else
    //        {
    //            A_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //            A_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //            A_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            A_weapon.GetComponent<Button>().interactable = true;

    //            A_weapon.GetComponent<Button>().targetGraphic = A_weapon.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



    //        }



    //    }
    //}
    //public void BtnAirAromorCheck()
    //{
    //    if (playerManager.instance.B_armorUpCount > 0)
    //    {



    //        if (playerManager.instance.b_scincefacility == false)
    //        {


    //            A_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //            A_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(true);
    //            A_armor.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            A_armor.GetComponent<Button>().targetGraphic = A_armor.GetComponent<ArmoryButton>().BtnOff.GetComponent<Image>();

    //            A_armor.GetComponent<Button>().interactable = false;



    //        }
    //        else
    //        {
    //            A_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(true);
    //            A_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //            A_armor.GetComponent<ArmoryButton>().offBtn.SetActive(false);

    //            A_armor.GetComponent<Button>().interactable = true;

    //            A_armor.GetComponent<Button>().targetGraphic = A_armor.GetComponent<ArmoryButton>().BtnOn.GetComponent<Image>();



    //        }



    //    }



    //}


    public void UpCountChek()
    {
        if (Btn_Num == 1)
        {
            if (playerManager.instance.M_GroundatkUpCount > 2)
            {
                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(true);

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

                UPBtn.GetComponent<Button>().interactable = false;

            }


        }
        else if (Btn_Num == 2)
        {
            if (playerManager.instance.M_GroundarmorUpCount > 2)
            {
                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(true);

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

                UPBtn.GetComponent<Button>().interactable = false;
            }

        }
        else if (Btn_Num == 3)
        {
            if (playerManager.instance.M_AiratkUpCount > 2)
            {
                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(true);

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

                UPBtn.GetComponent<Button>().interactable = false;

            }
        }
        else if (Btn_Num == 4)
        {
            if (playerManager.instance.M_AirarmorUpCount > 2)
            {
                UPBtn.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
                UPBtn.GetComponent<ArmoryButton>().offBtn.SetActive(true);

                UPBtn.GetComponent<Button>().targetGraphic = UPBtn.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

                UPBtn.GetComponent<Button>().interactable = false;
            }
        }


    }

    //public void WeaponUpCountChek()
    //{

    //    if (playerManager.instance.M_GroundatkUpCount > 2)
    //    {
    //        G_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //        G_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        G_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(true);

    //        G_weapon.GetComponent<Button>().targetGraphic = G_weapon.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

    //        G_weapon.GetComponent<Button>().interactable = false;

    //    }

    //}
    //public void ArmorUpCountCheck()
    //{
    //    if (playerManager.instance.M_GroundarmorUpCount > 2)
    //    {
    //        G_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //        G_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        G_armor.GetComponent<ArmoryButton>().offBtn.SetActive(true);

    //        G_armor.GetComponent<Button>().targetGraphic = G_armor.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

    //        G_armor.GetComponent<Button>().interactable = false;
    //    }

    //}
    //public void AirWeaponUpCountChek()
    //{

    //    if (playerManager.instance.M_AiratkUpCount > 2)
    //    {
    //        A_weapon.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //        A_weapon.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        A_weapon.GetComponent<ArmoryButton>().offBtn.SetActive(true);

    //        A_weapon.GetComponent<Button>().targetGraphic = A_weapon.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

    //        A_weapon.GetComponent<Button>().interactable = false;

    //    }

    //}
    //public void AirArmorUpCountCheck()
    //{
    //    if (playerManager.instance.M_AirarmorUpCount > 2)
    //    {
    //        A_armor.GetComponent<ArmoryButton>().BtnOn.SetActive(false);
    //        A_armor.GetComponent<ArmoryButton>().BtnOff.SetActive(false);
    //        A_armor.GetComponent<ArmoryButton>().offBtn.SetActive(true);

    //        A_armor.GetComponent<Button>().targetGraphic = A_armor.GetComponent<ArmoryButton>().offBtn.GetComponent<Image>();

    //        A_armor.GetComponent<Button>().interactable = false;
    //    }

    //}


    public void M_GroundAtkUpPlus()
    {
        playerManager.instance.M_GroundatkUpCount++;

    }

    public void M_GroundarmorUpPlus()
    {
        playerManager.instance.M_GroundarmorUpCount++;
    }

    public void M_AiratkUpPlus()
    {
        playerManager.instance.M_AiratkUpCount++;
    }
    public void M_AirarmorpPlus()
    {
        playerManager.instance.M_AirarmorUpCount++;
    }

}
