using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EntityManager : MonoBehaviour {
    public float outOfBounds = 9999;
    public float speed = 0.05f;
    public float offSet = 0.5f;
    public float dragDelay = 0.1f;
    public bool isAlert;
    public bool isMoving;
    public List<GameObject> units = new List<GameObject>();
    public GameObject unit;
    public GameObject arrow;
    [SerializeField]
    public Camera Camera;
    [SerializeField]
    public RectTransform SelectionBox;
    private Vector2 StartMousePosition;
    private float MouseDownTime;
    public LayerMask unitLayers;
    public GameObject[] AvailableObjects;
    // Use this for initialization
    void Start() {
        // replace with dynamic population of selective army/building choices 
        //AvailableObjects = new GameObject[2];
    }

    // Update is called once per frame
    void Update() {
    }

    public void CreateUnit()
    {
        // Instantiate(unit);
        //Creates unit where the mouse it on space press
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            units.Add(Instantiate(unit, new Vector3(hit.point.x + offSet, hit.point.y + offSet, hit.point.z + offSet), new Quaternion()));
        }

    }

    public void SetAllUnits(bool pStatus)
    {
        for (int i = 0; i < units.Count; i++)
        {
            units[i].GetComponent<EntityController>().setAlert(pStatus);
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

    public void CheckIfUnitInBox(Bounds Bound)
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (UnitsInSelectionbox(Camera.WorldToScreenPoint(units[i].transform.position), Bound))
            {
                units[i].GetComponent<EntityController>().setAlert(true);
            }
            else
            {
                units[i].GetComponent<EntityController>().setAlert(false);
            }
        }
    }

    public bool UnitsInSelectionbox(Vector2 pPosition, Bounds Bound)
    {
        return pPosition.x > Bound.min.x && pPosition.x < Bound.max.x && pPosition.y > Bound.min.y && pPosition.y < Bound.max.y;
    }

    public void SelectionBoxInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectionBox.sizeDelta = Vector2.zero;
            SelectionBox.gameObject.SetActive(true);
            StartMousePosition = Input.mousePosition;
            MouseDownTime = Time.time;
        }
        else if (Input.GetMouseButton(0) && MouseDownTime + dragDelay < Time.time)
        {
            ResizeSelectionBox();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SelectionBox.sizeDelta = Vector2.zero;
            SelectionBox.gameObject.SetActive(false);

            if (Physics.Raycast(Camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit) && hit.collider.TryGetComponent<EntityController>(out EntityController entity))
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    if (entity.getAlert())
                    {
                        entity.setAlert(false);
                    }
                    else
                    {
                        entity.setAlert(true);
                    }
                }
                else
                {
                    SetAllUnits(false);
                    entity.setAlert(true);
                }
            }
            else if (MouseDownTime + dragDelay > Time.time)
            {
                SetAllUnits(false);
            }


            MouseDownTime = 0;
        }
    }

    private void ResizeSelectionBox()
    {
        float width = Input.mousePosition.x - StartMousePosition.x;
        float height = Input.mousePosition.y - StartMousePosition.y;

        SelectionBox.anchoredPosition = new Vector2(StartMousePosition.x, StartMousePosition.y) + new Vector2(width / 2, height / 2);
        SelectionBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));

        Bounds bounds = new Bounds(SelectionBox.anchoredPosition, SelectionBox.sizeDelta);

        CheckIfUnitInBox(bounds);
    }

    public void DestroyUnit(GameObject pGameObject)
    {
        if (units.Contains(pGameObject))
        {
            units.Remove(pGameObject);
            Destroy(pGameObject);
        }
        else
        {
            throw new Exception("Object Not in EntityManager List");
        }

    }

    public void CreateUnit(Vector3 pPosition, int pObjectiveType)
    {
        // Instantiate(unit) + look into the creation of roation to be set. Direction of camera, to face player or rotation of building? Or inherent from parent ie building
        units.Add(Instantiate(AvailableObjects[pObjectiveType], pPosition, new Quaternion()));

    }

    public void CreateUnit(Vector3 pPosition, int pObjectiveType, bool pisGhost)
    {
        // Instantiate(unit) + look into the creation of roation to be set. Direction of camera, to face player or rotation of building? Or inherent from parent ie building
        units.Add(Instantiate(AvailableObjects[pObjectiveType], pPosition, new Quaternion()));
        units[units.Count-1].GetComponent<EntityController>().setGhost(pisGhost);

    }


}



//when unit is selected to build ie button press B
// spawn ghost with create unit
// track mouse movement till left mouse click
// destory unit
// create unit
