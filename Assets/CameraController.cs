using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCam;
    public GameObject player;
    public float smoothDelay = 5;

    public float zPosition = -10;

    public float maxZoom = 5f;

    public float minZoom = 2.5f;
    public NPCSystem[] NPCdetections;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bool playerDetected = false;

        foreach (var npc in NPCdetections)
        {
            if (npc.playerDetection)
            {
                playerDetected = true;
                break;
            }
        }
        Vector3 targetPosition = player.transform.position;
        targetPosition.z = zPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothDelay * Time.deltaTime);

    float targetSize = playerDetected ? minZoom : maxZoom;

    mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, targetSize, smoothDelay * Time.deltaTime);
    }
}
