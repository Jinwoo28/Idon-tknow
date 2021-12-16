using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.HUD;
using RTS.Player;

public class StarportButton : MonoBehaviour
{

    public GameObject BtnOn;
    public GameObject BtnOff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sciencecheck()
    {
        for (int i = 0; i < ActionFrame.instance.buttons.Count; i++)
        {
            Debug.Log(ActionFrame.instance.buttons[i].name);
            if (ActionFrame.instance.buttons[i].name == "ScineVessel")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_scincefacility == false)
                {


                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(true);




                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;





                }
                else
                {
                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(false);


                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOn.GetComponent<Image>();

                }


            }

        }

    }

    public void starportaddoncheck()
    {
        for (int i = 0; i < ActionFrame.instance.buttons.Count; i++)
        {
            Debug.Log(ActionFrame.instance.buttons[i].name);
            if (ActionFrame.instance.buttons[i].name == "Dropship")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_starportaddon == false)
                {


                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(true);




                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;





                }
                else
                {
                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(false);


                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOn.GetComponent<Image>();

                }


            }

        }


    }

    public void physicslabcheck()
    {

        for (int i = 0; i < ActionFrame.instance.buttons.Count; i++)
        {
            Debug.Log(ActionFrame.instance.buttons[i].name);
            if (ActionFrame.instance.buttons[i].name == "BattleCruiser")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_physicslab == false)
                {


                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(true);




                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;





                }
                else
                {
                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(false);


                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOn.GetComponent<Image>();

                }


            }

        }

    }

    public void armorycheck()
    {
        for (int i = 0; i < ActionFrame.instance.buttons.Count; i++)
        {
            Debug.Log(ActionFrame.instance.buttons[i].name);
            if (ActionFrame.instance.buttons[i].name == "Valkyrie")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_armory == false)
                {


                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(true);




                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;





                }
                else
                {
                    btnA.GetComponent<StarportButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<StarportButton>().BtnOff.SetActive(false);


                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<StarportButton>().BtnOn.GetComponent<Image>();

                }


            }

        }



    }
}
