using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


    public class ResetObject : MonoBehaviour
    {
        XRGrabInteractable m_GrabInteractable;
        [SerializeField] Transform returnToPosition;
        [SerializeField] float resetDelayTime;

        protected bool shouldReturnHome { get; set; }

        void Awake()
        {
            m_GrabInteractable = GetComponent<XRGrabInteractable>();
            returnToPosition.position = this.transform.position;
            shouldReturnHome = true;
        }

        protected void ReturnHome()
        {

            if (shouldReturnHome)
                transform.position = returnToPosition.position;
            Debug.Log("On method");
    }

        IEnumerator returnObj()
        {
            yield return new WaitForSeconds(resetDelayTime);
            ReturnHome();

        }

        private void OnTriggerEnter(Collider col)
        {
            Debug.Log("On trigger");
            if (col.gameObject.tag == "Ground")
            {
                Debug.Log("On ground");
            StartCoroutine(returnObj());
            }
        }
    }
