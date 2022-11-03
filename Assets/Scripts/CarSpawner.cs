using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarSpawner : MonoBehaviour
{
    static GameObject spawner;
    static GameObject destructor;

    public GameObject carS;

    static GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        car = carS;
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
    static public void instCW1()
    {
        spawner = GameObject.Find("W1");
        destructor = GameObject.Find("S3'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("W1"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[0]++;
    }
    static public void instCW2()
    {
        spawner = GameObject.Find("W2");
        destructor = GameObject.Find("E2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("W2"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[1]++;
    }
    static public void instCW3()
    {
        spawner = GameObject.Find("W3");
        destructor = GameObject.Find("N1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("W3"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[2]++;
    }
    static public void instCN1()
    {
        Debug.Log("In function");
        spawner = GameObject.Find("N1");
        destructor = GameObject.Find("E3'");
        Debug.Log(spawner.transform.position);
        Debug.Log(destructor.transform.position);
        Debug.Log(car);
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("N1"));
        CarMover.postion = destructor.transform.position;
        Debug.Log("ALready Spwned");
        SocketClient.carNo[3]++;
    }
    static public void instCN2()
    {
        spawner = GameObject.Find("N2");
        destructor = GameObject.Find("S2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("N2"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[4]++;
    }
    static public void instCN3()
    {
        spawner = GameObject.Find("N3");
        destructor = GameObject.Find("W1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("N3"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[5]++;
    }
    
    static public void instCE1()
    {
        spawner = GameObject.Find("E1");
        destructor = GameObject.Find("S3'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("E1"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[6]++;
    }
    static public void instCE2()
    {
        spawner = GameObject.Find("E2");
        destructor = GameObject.Find("W2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("E2"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[7]++;
    }
    static public void instCE3()
    {
        spawner = GameObject.Find("E3");
        destructor = GameObject.Find("N1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("E3"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[8]++;
    }
    
    static public void instCS1()
    {
        spawner = GameObject.Find("S1");
        destructor = GameObject.Find("W3'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("S1"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[9]++;
    }
    static public void instCS2()
    {
        spawner = GameObject.Find("S2");
        destructor = GameObject.Find("N2'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("S2"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[10]++;
    }
    static public void instCS3()
    {
        spawner = GameObject.Find("S3");
        destructor = GameObject.Find("E1'");
        Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        CarMover.areaInt = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName("S3"));
        CarMover.postion = destructor.transform.position;
        SocketClient.carNo[11]++;
    }
}

