using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed = 0.01f;
    public float rotSpeed = 0.05f;
    private float MaxSpeed = 1f;
    private float Resistance = 0.05f;
    public float ZoomResistance = 0.2f;
    public float ZoomSpeed = 0.5f;
    public float ZoomAcceleration = 0;
    public float CameraHeight = 20f;
    public float XAcceleration = 0;
    public float ZAcceleration = 0;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, CameraHeight, transform.position.z);
    }

    
    // Update is called once per frame
    void FixedUpdate() {

        //transform.position = new Vector3(transform.position.x + XAcceleration, transform.position.y, transform.position.z + ZAcceleration);
        transform.Translate(XAcceleration, ZoomAcceleration, ZAcceleration);
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (XAcceleration > -Resistance && XAcceleration < Resistance)
            {
                XAcceleration = 0;
            }
            else if (XAcceleration > 0)
            {
                XAcceleration -= Resistance;
            }
            else if (XAcceleration < 0)
            {
                XAcceleration += Resistance;
            }
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow))
        {
            if (ZAcceleration > -Resistance && ZAcceleration < Resistance)
            {
                ZAcceleration = 0;
            }
            else if (ZAcceleration > 0)
            {
                ZAcceleration -= Resistance;
            }
            else if (ZAcceleration < 0)
            {
                ZAcceleration += Resistance;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") == 0)
        {
            if (ZoomAcceleration > -ZoomResistance && ZoomAcceleration < ZoomResistance)
            {
                ZoomAcceleration = 0;
            }
            else if (ZoomAcceleration > 0)
            {
                ZoomAcceleration -= ZoomResistance;
            }
            else if (ZoomAcceleration < 0)
            {
                ZoomAcceleration += ZoomResistance;
            }
        }


    }

    public void AccelerateXPos()
    {
        if (XAcceleration < MaxSpeed)
        {
            XAcceleration += speed;
        }
    }

    public void AccelerateXNeg()
    {
        if ((XAcceleration * -1) < MaxSpeed)
        {
            XAcceleration -= speed;
        }
    }

    public void AccelerateZPos()
    {
        if (ZAcceleration < MaxSpeed)
        {
            ZAcceleration += speed;
        }
    }

    public void AccelerateZNeg()
    {
        if ((ZAcceleration * -1) < MaxSpeed)
        {
            ZAcceleration -= speed;
        }
    }

    public void ZoomAcceleratePos()
    {
        if (ZoomAcceleration < MaxSpeed)
        {
            ZoomAcceleration += ZoomSpeed;
        }
    }

    public void ZoomAccelerateNeg()
    {
        if ((ZoomAcceleration * -1) < MaxSpeed)
        {
            ZoomAcceleration -= ZoomSpeed;
        }
    }

    public float GetZoomSpeed()
    {
        return ZoomAcceleration;
    }

    public float GetHeight()
    {
        return transform.position.y;
    }

}
