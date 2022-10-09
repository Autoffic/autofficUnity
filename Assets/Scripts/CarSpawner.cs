using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarSpawner : MonoBehaviour
{
    GameObject spawner;
    GameObject destructor;
    public GameObject car;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            instCE1();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            instCE2();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            instCE3();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            instCN1();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            instCN2();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            instCN3();
        }
    }
    void instCE1()
    {
        spawner = GameObject.Find("E1");
        destructor = GameObject.Find("S3'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("E1"));
        CarMover.postion = destructor.transform.position;
    }
    void instCE2()
    {
        spawner = GameObject.Find("E2");
        destructor = GameObject.Find("W2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("E2"));
        CarMover.postion = destructor.transform.position;
    }
    void instCE3()
    {
        spawner = GameObject.Find("E3");
        destructor = GameObject.Find("N1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("E3"));
        CarMover.postion = destructor.transform.position;
    }
    void instCN1()
    {
        spawner = GameObject.Find("N1");
        destructor = GameObject.Find("E3'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("N1"));
        CarMover.postion = destructor.transform.position;
    }
    void instCN2()
    {
        spawner = GameObject.Find("N2");
        destructor = GameObject.Find("S2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("N2"));
        CarMover.postion = destructor.transform.position;
    }
    void instCN3()
    {
        spawner = GameObject.Find("N3");
        destructor = GameObject.Find("W1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("N3"));
        CarMover.postion = destructor.transform.position;
    }
    void instCW1()
    {
        spawner = GameObject.Find("W1");
        destructor = GameObject.Find("S3'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("W1"));
        CarMover.postion = destructor.transform.position;
    }
    void instCW2()
    {
        spawner = GameObject.Find("W2");
        destructor = GameObject.Find("E2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("W2"));
        CarMover.postion = destructor.transform.position;
    }
    void instCW3()
    {
        spawner = GameObject.Find("W3");
        destructor = GameObject.Find("N1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("W3"));
        CarMover.postion = destructor.transform.position;
    }
    void instCS1()
    {
        spawner = GameObject.Find("S1");
        destructor = GameObject.Find("W3'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("S1"));
        CarMover.postion = destructor.transform.position;
    }
    void instCS2()
    {
        spawner = GameObject.Find("S2");
        destructor = GameObject.Find("N2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("S2"));
        CarMover.postion = destructor.transform.position;
    }
    void instCS3()
    {
        spawner = GameObject.Find("S3");
        destructor = GameObject.Find("E1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("S3"));
        CarMover.postion = destructor.transform.position;
    }
}

