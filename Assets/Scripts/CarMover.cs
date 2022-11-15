using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMover : MonoBehaviour
{
    NavMeshAgent car;

    // Start is called before the first frame update
    void Start()
    {
        car = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate()
    {
        car.isStopped = false;
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, 3.0f))
        {
            if (hit.collider.gameObject.name == "Car_1" || hit.collider.tag == "traffic")
            {
                car.isStopped = true;
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
    }

}
