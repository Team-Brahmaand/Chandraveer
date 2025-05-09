using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invoke : MonoBehaviour
{
    public GameObject theobject;
    void Start()
    {
        
    }

    void makeActive()
    {
        theobject.SetActive(true);
    }

    
    void Update()
    {
        Invoke("makeActive", 22f);
    }
}
