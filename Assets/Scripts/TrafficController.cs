using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    public GameObject TrafficEast;
    public GameObject TrafficWest;
    public GameObject TrafficNorth;
    public GameObject TrafficSouth;
    BoxCollider te;
    BoxCollider tw;
    BoxCollider tn;
    BoxCollider ts;

    // Start is called before the first frame update
    void Start()
    {
        te = TrafficEast.GetComponent<BoxCollider>();
        tw = TrafficWest.GetComponent<BoxCollider>();
        tn = TrafficNorth.GetComponent<BoxCollider>();
        ts = TrafficSouth.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(SocketClient.config.GetType());
        switch (SocketClient.config)
        {
            case 0:
                removeAll();
                trafficEast();
                trafficWest();
                break;
            case 1:
                removeAll();
                trafficNorth();
                trafficSouth();
                break;
            case 2:
                removeAll();
                trafficWest();
                trafficSouth();
                break;
            case 3:
                removeAll();
                trafficNorth();
                trafficSouth();
                break;
            default:
                break;
        };
        if (Input.GetKeyDown(KeyCode.A))
        {
            trafficEast();
        }
        if (Input.GetKeyDown(KeyCode.S))
        { trafficWest(); }
        if (Input.GetKeyDown(KeyCode.D))
        { trafficNorth(); }
        if (Input.GetKeyDown(KeyCode.F))
        { trafficSouth(); }
        if (Input.GetKeyDown(KeyCode.M))
        {
            removeAll();
        }
    }

    void removeAll()
    {
        te.enabled = false;
        tw.enabled = false;
        tn.enabled = false;
        ts.enabled = false;
    }
    void trafficEast()
    {

        te.enabled = true;
    }
    void trafficWest()
    {
        tw.enabled = true;
    }
    void trafficNorth()
    {
        tn.enabled = true;
    }
    void trafficSouth()
    {
        ts.enabled = true;
    }

}
