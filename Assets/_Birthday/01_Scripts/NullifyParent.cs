using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullifyParent : MonoBehaviour
{
    public void Nullify()
    {
        transform.parent = null;
    }
}
