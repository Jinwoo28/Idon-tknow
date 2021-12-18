using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
    public class ImageSet : MonoBehaviour
    {
        public static ImageSet instance = null;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void setImage(Sprite image)
        {
            this.GetComponent<Image>().sprite = image;
            GetComponent<Image>().color = new Color(255, 255, 255, 255);


        }
        public void clearImage()
        {

            GetComponent<Image>().sprite = null;
            GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }
}