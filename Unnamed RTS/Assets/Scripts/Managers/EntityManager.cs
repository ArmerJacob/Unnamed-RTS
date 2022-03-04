using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour {
    public float outOfBounds = 9999;
    public float speed = 0.05f;
    public float offSet = 0.5f;
    public bool isAlert;
    public bool isMoving;
    public List<GameObject> units = new List<GameObject>();
    public GameObject unit;
    public GameObject arrow;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void CreateUnit()
    {
            // Instantiate(unit);
            //Creates unit where the mouse it on space press
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                units.Add(Instantiate(unit,new Vector3(hit.point.x + offSet, hit.point.y + offSet, hit.point.z + offSet), new Quaternion()));
            }
       
    }

    public void CheckIfUnitSelected(bool pMultiSelect)
    {

            //First ray cast determines if this object has been hit
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int ignore = -1;
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
            for (int i = 0; i < units.Count; i++)
            {
                if (hit.transform.position == units[i].transform.position)
                {

                  units[i].GetComponent<EntityController>().setAlert(true);
                    ignore = i;
                }
            }
            if(pMultiSelect == false)
            {
                for (int i = 0; i < units.Count; i++)
                {
                    if (i != ignore)
                    {
                        units[i].GetComponent<EntityController>().setAlert(false);
                    }
                }
            }

        }

    }

    public void CheclForUnitOrders()
    {

        //Moves to target if object is listening for order

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].GetComponent<EntityController>().getAlert() == true)
                {
                    units[i].GetComponent<EntityController>().setTarget(hit.point);
                    units[i].GetComponent<EntityController>().setMoving(true);

                }
            }
            Instantiate(arrow, new Vector3(hit.point.x, hit.point.y + 2, hit.point.z), new Quaternion());
        }
    }
    
}
