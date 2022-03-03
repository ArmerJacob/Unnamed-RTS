using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed = 0.1f;
    public float rotSpeed = 0.05f;
    private float startSpeed = 0.1f;
    private float incriment = 0.01f;
    public float ZoomSpeed = 0.5F;
    public float CameraHeight = 20f;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, CameraHeight, transform.position.z);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0 && transform.position.y - ZoomSpeed > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - ZoomSpeed, transform.position.z);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.position.y + ZoomSpeed <= 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + ZoomSpeed, transform.position.z);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, CameraHeight, transform.position.z);
        }

    }
}
