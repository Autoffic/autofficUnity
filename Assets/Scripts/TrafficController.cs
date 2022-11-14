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
        switch (SocketClient.config)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        };

    }

    void openAll()
    {
        te.size = new Vector3(0, 0, 0);
        tw.size = new Vector3(0, 0, 0);
        ts.size = new Vector3(0, 0, 0);
        tn.size = new Vector3(0, 0, 0);

    }

    void halfClose(BoxCollider traffic)
    {
        traffic.size = new Vector3(1f, 1f, 2.36f);
        traffic.center = new Vector3(0, 0.5f, 2.36f);
    }

    void close(BoxCollider traffic)
    {
        traffic.size = new Vector3(1f, 1f, 7f);
        traffic.center = new Vector3(0, 0.5f, 0);
    }

}
