using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private int end;

    // Start is called before the first frame update
 void Start()
    {
        offset = transform.position - player.transform.position;
        end = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            end = 1;
        }
        else if (end != 1) //This is here to prevent unity from throwing hundreds of errors after the game object is destroyed, but it doesn't work, and I'm done trying to get it to work. It's not required for the project.
        {
            transform.position = player.transform.position + offset;
        }
    }
}
