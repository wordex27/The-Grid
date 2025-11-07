using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCSystem : MonoBehaviour
{

    public bool playerDetection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetection && Input.GetKeyDown(KeyCode.X))
        {
            print("Dialogue Started!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetection = true;
        }
    }



    void OnTriggerExit2D(Collider2D collision)
{
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetection = false;
        }
}
}
