using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{
    public GameObject template;
    private int instanceId = 0;
    //private NavMeshPath navMeshPath = new NavMeshPath();

    public void Start()
    {

    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                GameObject test = Instantiate(template);
                test.name = instanceId.ToString();
                test.transform.position = hit.point;
                instanceId++;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                this.GetComponent<NavMeshAgent>().destination = hit.point;

                //navMeshPath.ClearCorners();
                //if (NavMesh.CalculatePath(this.transform.position, hit.point, 1, navMeshPath))
                //{
                //    Debug.Log("可以寻路到");
                //}
            }
        }
    }
}

