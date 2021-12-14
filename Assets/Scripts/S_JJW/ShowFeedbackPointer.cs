using UnityEngine;
using UnityEngine.AI;

namespace Graphics.Feedback.Scripts

{
    public class ShowFeedbackPointer : MonoBehaviour
    {
        private readonly FeedbackPointer _feedbackPointer = new FeedbackPointer();

        [SerializeField]
        private float _feedbackPointerScale = 1f;

        [SerializeField]
        private GameObject _moveToIndicator;


        public void InteractOnPerformed(Vector2 position)
        {
           

         

  
        }

        private void Start()
        {
            _feedbackPointer.PreparePointer(_moveToIndicator, _feedbackPointerScale);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                InteractOnPerformed(Input.mousePosition);
        }
    }
}