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
        if (Input.GetKeyDown(KeyCode.A))
        { trafficEast(); }
        if (Input.GetKeyDown(KeyCode.S))
        { trafficWest(); }
        if (Input.GetKeyDown(KeyCode.D))
        { trafficNorth(); }
        if (Input.GetKeyDown(KeyCode.F))
        { trafficSouth(); }
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
        removeAll();
        te.enabled = true;
    }
    void trafficWest()
    {
        removeAll();
        tw.enabled = true;
    }
    void trafficNorth()
    {
        removeAll();
        tn.enabled = true;
    }
    void trafficSouth()
    {
        removeAll();
        ts.enabled = true;
    }

}
