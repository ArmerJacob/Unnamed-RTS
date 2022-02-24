using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlManager : MonoBehaviour {

    public GameObject entityManager;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.V))
        {
            entityManager.GetComponent<EntityManager>().CreateUnit();
         }


        if (Input.GetMouseButtonDown(0))
        {
            entityManager.GetComponent<EntityManager>().CheckIfUnitSelected();
        }

        if (Input.GetMouseButtonDown(1))
        {
            entityManager.GetComponent<EntityManager>().CheclForUnitOrders();
        }
    }
}
