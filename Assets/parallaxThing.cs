using System;
using System.Numerics;
using UnityEngine;

public class parallaxThing : MonoBehaviour
{

    public GameObject targ = new  GameObject();
    UnityEngine.Vector3 adjPos = new UnityEngine.Vector3(0,0,0);
    
    public int xOffset;
    
    public int yOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        adjPos.x = -(targ.transform.position.x)/3 + xOffset;
        adjPos.y = -(targ.transform.position.y)/3 + yOffset; 
        adjPos.z = 2;
        transform.position = adjPos;
    }
}
