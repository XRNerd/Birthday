using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class SimpleRotate : MonoBehaviour
{
    [SerializeField] Vector3 rotation;
    [SerializeField] bool setRandomAtStart = false;
    [SerializeField, ShowIf(nameof(setRandomAtStart))] float randomMagnitude = 1f;

    private void Start()
    {
        if (setRandomAtStart)
        {
            rotation = Random.onUnitSphere * randomMagnitude;
        }
    }
    void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
    }
}
