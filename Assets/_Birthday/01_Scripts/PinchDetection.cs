using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction;

public class PinchDetection : MonoBehaviour
{
    [SerializeField] OVRHand hand;

    //Detect a pinch using the Oculus intergration Library
    public void DetectPinch(OVRHand hand)
    {
        if (hand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Debug.Log("Pinch Detected");
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
        DetectPinch(hand);
    }
}
