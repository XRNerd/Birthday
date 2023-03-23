using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using UnityEngine.Events;
public class PinchDetection : MonoBehaviour
{

    [SerializeField] UnityEvent pinchEvent = new UnityEvent();



    bool isPinching = false;

    //Detect a pinch using the Oculus intergration Library
    public bool isHandPinching(OVRHand hand)
    {
        isPinching = hand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        return isPinching;
        // if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        // {
        //     Debug.Log(hand.name + " Pinch Detected");
        //     isPinching = true;
        //     return true;
        // }
        // else
        // {
        //     isPinching = false;
        //     return false;
        // }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get the dominant hand from the OVRInput


        isHandPinching(Game.Instance.lHand);
        isHandPinching(Game.Instance.rHand);


    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision Detected");
        //if other has physics layer "Pinchable" and isPinching is true
        if (other.gameObject.layer == LayerMask.NameToLayer("Fingers") && isPinching == true)
        {
            //invoke the pinch event
            PinchEvent();
        }
    }

    public void PinchEvent()
    {
        pinchEvent.Invoke();
    }
}
