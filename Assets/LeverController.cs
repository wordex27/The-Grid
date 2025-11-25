using System.Collections;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class Levercontroller : MonoBehaviour
{

    public bool leverPushed = false;
    public int leverStatus = -1;

    public bool playerInRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown("space"))
            leverStatus *= -1;

        if (leverStatus == 1)
            leverPushed = true;
        else
            leverPushed = false;
    }


    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
        void OnTriggerExit2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
