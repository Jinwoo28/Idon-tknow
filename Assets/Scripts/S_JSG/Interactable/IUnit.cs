using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Interactables
{
    public class IUnit : Interactable
    {

        public UI.HUD.PlayerAction actions;
        public Sprite Unitimage;

       
        public override void OnInteractEnter()
        {
            UI.HUD.ActionFrame.instance.SetActionButtons(actions); //버튼 활성화
            UI.HUD.ImageSet.instance.setImage(Unitimage);
            base.OnInteractEnter();
        }
        public override void OnInteractExit()
        {
            UI.HUD.ActionFrame.instance.ClearActions();
            UI.HUD.ImageSet.instance.clearImage();
            base.OnInteractExit();
        }
        public bool isSelected()
        {
            return isInteracting;
        }
    }
}