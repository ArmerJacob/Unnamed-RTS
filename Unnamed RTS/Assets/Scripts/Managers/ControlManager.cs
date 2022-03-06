using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlManager : MonoBehaviour {

    public GameObject Player;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.V))
        {
            Player.GetComponent<EntityManager>().CreateUnit();
         }

        Player.GetComponent<EntityManager>().SelectionBoxInputs();

        //if (Input.GetMouseButtonUp(0))
        //{
        //    bool multiSelect;
        //    if (Input.GetKey(KeyCode.LeftShift))
        //    {
        //        multiSelect = true;
        //    }
        //    else
        //    {
        //        multiSelect = false;
        //    }
        //    entityManager.GetComponent<EntityManager>().CheckIfUnitSelected(multiSelect);
        //}


        if (Input.GetMouseButtonDown(1))
        {
            Player.GetComponent<EntityManager>().CheclForUnitOrders();
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Player.GetComponent<CameraController>().AccelerateXNeg();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Player.GetComponent<CameraController>().AccelerateXPos();
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Player.GetComponent<CameraController>().AccelerateZPos();
        }


        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Player.GetComponent<CameraController>().AccelerateZNeg();
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && Player.GetComponent<CameraController>().GetHeight() - Player.GetComponent<CameraController>().GetZoomSpeed() >= 5)
        {
            Player.GetComponent<CameraController>().ZoomAccelerateNeg();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && Player.GetComponent<CameraController>().GetHeight() + Player.GetComponent<CameraController>().GetZoomSpeed() <= 40)
        {
            Player.GetComponent<CameraController>().ZoomAcceleratePos();
        }
    }


}
