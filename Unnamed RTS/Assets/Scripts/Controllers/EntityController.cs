using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityController : MonoBehaviour {
    public bool isAlert = false;
    public bool isMoving = false;
    private bool madeRing = false;
    public float outOfBounds = 9999;
    public float speed = 0.05f;
    public float offSet = 0.5f;
    Vector3 target;
    Assets.Scripts.EntityMovement movement;
    public NavMeshAgent agent;
    public GameObject Ring;
    private GameObject ringObject;


    // Use this for initialization
    void Start () {
        movement = new Assets.Scripts.EntityMovement();
        target = new Vector3(outOfBounds, 0, outOfBounds);

    }
	
	// Update is called once per frame
	void Update () {
        CheckIfAtTarget();
        if (isAlert == true)
        {
            ringObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z);
        }
    }

    void CheckIfAtTarget()
    {
        if(target.x > transform.position.x - offSet && target.x < transform.position.x + offSet && target.z > transform.position.z - offSet && target.z < transform.position.z + offSet)
        {
            isMoving = false;
            target.x = outOfBounds;
            target.z = outOfBounds;
           // Destroy(privateArrow);

        }
    }

    public bool getAlert()
    {
        return isAlert;
    }

    public void setAlert(bool pAlert)
    {
        if (pAlert == true && madeRing == false)
        {
            ringObject = Instantiate(Ring, new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z), Ring.transform.rotation);
            madeRing = true;
        }
        else if (pAlert == false)
        {
            Destroy(ringObject);
            madeRing = false;
        }
        isAlert = pAlert;
    }

    public void setTarget(Vector3 pTarget)
    {
       // Destroy(privateArrow);
        agent.SetDestination(pTarget);
        target = pTarget;
    }

    public Vector3 getTarget()
    {
        return target;
    }

    public void setMoving(bool pMoving)
    {
        isMoving = pMoving;
    }

    public bool getMoving()
    {
        return isMoving;
    }
}
