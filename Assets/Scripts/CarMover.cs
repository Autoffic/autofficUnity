using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarMover : MonoBehaviour
{
    static public Vector3 postion;
    static public int areaInt;

    // Start is called before the first frame update
    void Start()
    {
        var car = GetComponent<NavMeshAgent>();

        car.areaMask = areaInt;

        car.SetDestination(postion);
    }

}
