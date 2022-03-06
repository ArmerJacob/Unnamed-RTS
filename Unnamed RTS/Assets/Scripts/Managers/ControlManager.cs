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

        entityManager.GetComponent<EntityManager>().SelectionBoxInputs();

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
            entityManager.GetComponent<EntityManager>().CheclForUnitOrders();
        }
    }


}
