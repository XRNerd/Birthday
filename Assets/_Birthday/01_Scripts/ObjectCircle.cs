using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

public class ObjectCircle : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public int numberOfObjects;

    public float distanceFromCenter;

    public float angleBetweenObjects => 360f / numberOfObjects;

    public float angleOffset;

    [Button]
    public void SpawnObjects()
    {
        List<Transform> children = new List<Transform>();
        children = GetComponentsInChildren<Transform>().Where(t => t != transform).ToList();
        foreach (Transform child in children)
        {
            if (child) DestroyImmediate(child.gameObject);
        }

        for (int i = 0; i < numberOfObjects; i++)
        {
            var angle = angleBetweenObjects * i + angleOffset;
            var position = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * distanceFromCenter;
            var rotation = Quaternion.Euler(0, angle, 0);

            //spawn as prefab
#if UNITY_EDITOR
            var newObject = PrefabUtility.InstantiatePrefab(prefabToSpawn) as GameObject;
            newObject.transform.position = position;
            newObject.transform.rotation = rotation;
            newObject.transform.SetParent(transform);
#else
            var newObject = Instantiate(prefabToSpawn, position, rotation, transform);
#endif
        }
    }
}
