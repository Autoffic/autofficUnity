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
            carInst("SOUTH", "lane0");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            carInst("SOUTH", "lane1");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            carInst("SOUTH", "lane2");
        }
    }
    static public void carInst(string direction, string lane)
    {
        string position = "";
        switch (direction)
        {
            case "NORTH":
                position += "N";

                break;
            case "EAST":
                position += "E";
                break;
            case "WEST":
                position += "W";
                break;
            case "SOUTH":
                position += "S";
                break;
            default:

                break;
        }
        switch (lane)
        {
            case "lane0":
                position += "1";
                break;
            case "lane1":
                position += "2";
                break;
            case "lane2":
                position += "3";
                break;
            default:
                Debug.Log("Invalid Input");
                return;
        }
        spawner = GameObject.Find(position);
        string destructorPos = "S3'";
        int arrayPoint = 0;
        switch (position)
        {
            case "W1":
                destructorPos = "S3'";
                arrayPoint = 0;
                break;
            case "W2":
                destructorPos = "E2'";
                arrayPoint = 1;
                break;
            case "W3":
                destructorPos = "N1'";
                arrayPoint = 2;
                break;
            case "N1":
                destructorPos = "E3'";
                arrayPoint = 3;
                break;
            case "N2":
                destructorPos = "S2'";
                arrayPoint = 4;
                break;
            case "N3":
                destructorPos = "W1'";
                arrayPoint = 5;
                break;
            case "E1":
                destructorPos = "S3'";
                arrayPoint = 6;
                break;
            case "E2":
                destructorPos = "W2'";
                arrayPoint = 7;
                break;
            case "E3":
                destructorPos = "N1'";
                arrayPoint = 8;
                break;
            case "S1":
                destructorPos = "W3'";
                arrayPoint = 9;
                break;
            case "S2":
                destructorPos = "N2'";
                arrayPoint = 10;
                break;
            case "S3":
                destructorPos = "E1'";
                arrayPoint = 11;
                break;

        }
        var c1 = Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        destructor = GameObject.Find(destructorPos);
        c1.transform.parent = GameObject.Find("SocketMap").transform;
        var nav1 = c1.GetComponent<NavMeshAgent>();
        nav1.SetDestination(destructor.transform.position);
        nav1.areaMask = (1 << NavMesh.GetAreaFromName("Walkable")) + (1 << NavMesh.GetAreaFromName(position));

        destructorPos += "N";
        position += "N";
        spawner = GameObject.Find(position);
        var c2 = Instantiate(car, spawner.transform.position, spawner.transform.rotation);
        destructor = GameObject.Find(destructorPos);
        c2.transform.parent = GameObject.Find("NormalMap").transform;
        var nav2 = c2.GetComponent<NavMeshAgent>();
        Debug.Log("for nav2 destructor is " + destructorPos + " " + destructor.transform.position);
        nav2.SetDestination(destructor.transform.position);
        nav2.areaMask = nav1.areaMask;
        SocketClient.carNo[arrayPoint]++;
    }

}

