using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMover : MonoBehaviour
{
    static public Vector3 postion;
    static public int areaInt;

    NavMeshAgent car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<NavMeshAgent>();

        car.areaMask = areaInt;

        car.SetDestination(postion);
    }

    private void FixedUpdate()
    {
        car.isStopped = false;
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 3.0f))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.name == "Car_1" || hit.collider.tag == "traffic")
            {
                car.isStopped = true;
            }
        }
    }

}
