using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    [SerializeField] private GameObject destroyableObject;

    public void DestroyAnObject()
    {
        Destroy(destroyableObject);
    }
}
