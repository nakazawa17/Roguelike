using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerPosition;
    Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = Camera.main.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = playerPosition.transform.position;

        cameraPosition.y = playerPosition.transform.position.y - 1;
        cameraPosition.z = -30;
        Camera.main.gameObject.transform.position = cameraPosition;
    }
}
