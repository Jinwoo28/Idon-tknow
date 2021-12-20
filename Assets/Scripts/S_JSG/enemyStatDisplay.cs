using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Units
{
    public class enemyStatDisplay : MonoBehaviour
    {

        public float maxHealth, armor, currentHealth, maxmp, mp;
        [SerializeField] private Image healthBarAmount;

        private bool isPlayerUnit = false;
        void Start()
        {

        }
        public void SetStatatDisplayUnit(UnitStatType.Base stats, bool isPlayer)
        {
            maxHealth = stats.health;
            armor = stats.armor;
            isPlayerUnit = isPlayer;
            maxmp = stats.maxmp;
            mp = stats.mp;


            currentHealth = maxHealth;
        }

        public void SetStatDisplayBasicBuilding(Building.BuildingStatType.Base stats, bool isPLayer)
        {
            maxHealth = stats.health;
            armor = stats.armor;
            isPlayerUnit = isPLayer;


            currentHealth = maxHealth;
        }
        // Update is called once per frame
        void Update()
        {
            HandleHealth();
        }
        public void TakeDamage(float damage)
        {
            float totalDamage = damage - armor;
            currentHealth -= totalDamage;
        }
        private void HandleHealth()
        {
            Camera camera = Camera.main;
            gameObject.transform.LookAt(gameObject.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
            healthBarAmount.fillAmount = currentHealth / maxHealth;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            if (isPlayerUnit)
            {
                //InputManager.InputHandler.instance.selectedUnits.Remove(gameObject.transform.parent);
                //RTS.Player.playerManager.instance.supply -= gameObject.transform.parent.GetComponent<Enemy.enemyUnit>().baseStats.supply;
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                RTS.Player.GameManager.instance.EnemyCheck.Remove(gameObject.transform.parent.gameObject);
                // for (int i = 0;i<= RTS.Player.GameManager.instance.BuildingCheck.Count;i++)
                // {
                //     // RTS.Player.GameManager.instance.BuildingCheck[i].GetComponent<Building.Player.PlayerBuilding>().buildingType.name==""
                //     Debug.Log(RTS.Player.GameManager.instance.BuildingCheck[i].GetComponent<Building.Player.PlayerBuilding>().buildingType.name);

                // //if (RTS.Player.GameManager.instance.BuildingCheck[i].GetComponent<Building.Player.PlayerBuilding>().buildingType.name == gameObject.GetComponentInParent<Building.Player.PlayerBuilding>().buildingType.name)
                // //   {

                // //    }

                // }
                //RTS.Player.GameManager.instance.buildingnamecheck(this.gameObject.transform.parent.GetComponent<Building.Enemy.enemyBuilding>().buildingType.name);
               // RTS.Player.playerManager.instance.maxsupply -= gameObject.transform.parent.GetComponent<Building.Enemy.enemyBuilding>().baseStats.supply;
                Destroy(gameObject.transform.parent.parent.gameObject);
            }
        }
    }
}
