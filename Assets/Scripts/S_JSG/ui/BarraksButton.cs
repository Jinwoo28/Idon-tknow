using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UI.HUD;
using RTS.Player;
public class BarraksButton : MonoBehaviour
{

   

    public GameObject BtnOn;
    public GameObject BtnOff;
    


    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        academycheck();

    }
    

    public void academycheck()
    {

        for (int i = 0; i < ActionFrame.instance.buttons.Count; i++)
        {
            Debug.Log(ActionFrame.instance.buttons[i].name);
          if  (ActionFrame.instance.buttons[i].name == "Firebat")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_academy == false)
                {


                    btnA.GetComponent<BarraksButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<BarraksButton>().BtnOff.SetActive(true);



                   
                    btnB.targetGraphic = btnA.GetComponent<BarraksButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;





                }
                else
                {
                    btnA.GetComponent<BarraksButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<BarraksButton>().BtnOff.SetActive(false);


                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<BarraksButton>().BtnOn.GetComponent<Image>();

                }

                
            }

          else if (ActionFrame.instance.buttons[i].name== "Medic")
            {
                GameObject btnA = ActionFrame.instance.buttons[i];
                Button btnB = btnA.GetComponent<Button>();
                if (playerManager.instance.b_academy == false)
                {


                    btnA.GetComponent<BarraksButton>().BtnOn.SetActive(false);
                    btnA.GetComponent<BarraksButton>().BtnOff.SetActive(true);




                    btnB.targetGraphic = btnA.GetComponent<BarraksButton>().BtnOff.GetComponent<Image>();


                    // firebatBtn.spriteState.disabledSprite

                    btnB.interactable = false;


                    break;


                }
                else
                {
                    btnA.GetComponent<BarraksButton>().BtnOn.SetActive(true);
                    btnA.GetComponent<BarraksButton>().BtnOff.SetActive(false);


                    btnB.interactable = true;
                    btnB.targetGraphic = btnA.GetComponent<BarraksButton>().BtnOn.GetComponent<Image>();

                    break;

                }


            }

        }

        
    }

   

}
