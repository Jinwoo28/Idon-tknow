using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.HUD;
using RTS.Player;

public class FactoryButton : MonoBehaviour
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

    public void armorycheck()
    {

        for (int i = 0; i < ActionFrame.instance.buttons.Count; i++)
        {
            Debug.Log(ActionFrame.instance.buttons[i].name);
            if (ActionFrame.instance.buttons[i].name == "Goliath")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_armory == false)
                {


                    btnA.GetComponent<FactoryButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<FactoryButton>().BtnOff.SetActive(true);




                    btnB.targetGraphic = btnA.GetComponent<FactoryButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;





                }
                else
                {
                    btnA.GetComponent<FactoryButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<FactoryButton>().BtnOff.SetActive(false);


                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<FactoryButton>().BtnOn.GetComponent<Image>();

                }


            }

        }
    }

    public void factoryaddOn()
    {
        for (int i = 0; i < ActionFrame.instance.buttons.Count; i++)
        {
            Debug.Log(ActionFrame.instance.buttons[i].name);
            if (ActionFrame.instance.buttons[i].name == "SiegeTank")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_factoryaddon == false)
                {


                    btnA.GetComponent<FactoryButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<FactoryButton>().BtnOff.SetActive(true);




                    btnB.targetGraphic = btnA.GetComponent<FactoryButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;





                }
                else
                {
                    btnA.GetComponent<FactoryButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<FactoryButton>().BtnOff.SetActive(false);
                    

                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<FactoryButton>().BtnOn.GetComponent<Image>();

                }


            }

        }

    }

}
