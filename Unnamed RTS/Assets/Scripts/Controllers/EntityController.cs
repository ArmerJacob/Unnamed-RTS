using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityController : MonoBehaviour {
    public bool isAlert = false;
    public bool isMoving = false;
    public float outOfBounds = 9999;
    public float speed = 0.05f;
    public float offSet = 0.5f;
    Vector3 target;
    Assets.Scripts.EntityMovement movement;
    public NavMeshAgent agent;


    // Use this for initialization
    void Start () {
        movement = new Assets.Scripts.EntityMovement();
        target = new Vector3(outOfBounds, 0, outOfBounds);

    }
	
	// Update is called once per frame
	void Update () {
        CheckIfAtTarget();
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
