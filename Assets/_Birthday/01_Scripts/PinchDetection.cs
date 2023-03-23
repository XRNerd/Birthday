using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;
using UnityEngine.Events;
public class PinchDetection : MonoBehaviour
{

    [SerializeField] UnityEvent pinchEvent = new UnityEvent();

    [SerializeField] OVRHand lHand;
    [SerializeField] OVRHand rHand;

    bool isPinching = false;

    //Detect a pinch using the Oculus intergration Library
    public bool isHandPinching(OVRHand hand)
    {
        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Debug.Log(hand.name + " Pinch Detected");
            isPinching = true;
            return true;
        }
        else{
            isPinching = false;
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Get the dominant hand from the OVRInput

        if(isPinching == false)
        {
            isHandPinching(lHand);
            isHandPinching(rHand);
        }

    }

    public void PinchEvent()
    {
        pinchEvent.Invoke();
    }
}
