    using System.Numerics;
    using Unity.VisualScripting;
    using UnityEngine;

    public class Lever : MonoBehaviour
    {

        public GameObject lever;
        private Levercontroller leverController;

        public float t = 0f;

        public float lerpTime = 1f;
        public float lerpSpeed;

        public float changeY;

        public float changeX;

        public float z;

        UnityEngine.Vector3 leverControlledObject = new UnityEngine.Vector3();
        UnityEngine.Vector3 wantedPosition;

        UnityEngine.Vector3 temporary;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            leverController = lever.GetComponent<Levercontroller>();
            leverControlledObject.x = transform.position.x;
            leverControlledObject.y = transform.position.y;
            leverControlledObject.z = z;
            wantedPosition = new UnityEngine.Vector3(changeX, changeY, z);
        }

        // Update is called once per frame
        void Update()
        {
            if (leverController.leverPushed == true){

                t += Time.deltaTime/lerpTime;            }
            else
            {
                t -= Time.deltaTime/lerpTime;
            }

            t = Mathf.Clamp01(t);
            transform.position = UnityEngine.Vector3.Lerp(leverControlledObject, leverControlledObject + wantedPosition, t);
        }
}
