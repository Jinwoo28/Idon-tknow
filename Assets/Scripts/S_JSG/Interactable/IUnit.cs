using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
    public class IUnit : Interactable
    {

        public UI.HUD.PlayerAction actions;
        public override void OnInteractEnter()
        {
            UI.HUD.ActionFrame.instance.SetActionButtons(actions); //��ư Ȱ��ȭ
            base.OnInteractEnter();
        }
        public override void OnInteractExit()
        {
            UI.HUD.ActionFrame.instance.ClearActions();
            base.OnInteractExit();
        }
        public bool isSelected()
        {
            return isInteracting;
        }
    }
}