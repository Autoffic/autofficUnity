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
    public GameObject TrafficEasttra;
    public GameObject TrafficWesttra;
    public GameObject TrafficNorthtra;
    public GameObject TrafficSouthtra;
    BoxCollider tetra;
    BoxCollider twtra;
    BoxCollider tntra;
    BoxCollider tstra;
    double updatedTime = 0;
    int traditionalConfig = 0;
    // Start is called before the first frame update
    void Start()
    {
        te = TrafficEast.GetComponent<BoxCollider>();
        tw = TrafficWest.GetComponent<BoxCollider>();
        tn = TrafficNorth.GetComponent<BoxCollider>();
        ts = TrafficSouth.GetComponent<BoxCollider>();
        tetra = TrafficEasttra.GetComponent<BoxCollider>();
        twtra = TrafficWesttra.GetComponent<BoxCollider>();
        tntra = TrafficNorthtra.GetComponent<BoxCollider>();
        tstra = TrafficSouthtra.GetComponent<BoxCollider>();
        closeTrafficConfig(te, tn, ts, tw);
        closeTrafficConfig(tetra, tntra, tstra, twtra);
    }

    // Update is called once per frame
    void Update()
    {

        if (!((Time.realtimeSinceStartupAsDouble - updatedTime) < 10))

        {
            if ((Time.realtimeSinceStartupAsDouble - updatedTime) > 31)
            {
                switch (SocketClient.config)
                {
                    case 0:

                        closeTrafficConfig(te, tw, tn, ts);
                        Debug.Log("case 1");
                        bothOpen(te);
                        bothOpen(tw);
                        break;
                    case 1:
                        closeTrafficConfig(te, tw, tn, ts);
                        Debug.Log("case 2");

                        bothOpen(tn);
                        bothOpen(ts);
                        break;
                    case 2:
                        closeTrafficConfig(te, tw, tn, ts);
                        Debug.Log("Case 3");
                        middleClose(tw);
                        middleClose(te);
                        break;
                    case 3:
                        closeTrafficConfig(te, tw, tn, ts);
                        Debug.Log("Case 4");

                        middleClose(tn);
                        middleClose(ts);
                        break;
                    default:
                        Debug.Log("Case invalid");
                        closeTrafficConfig(te, tw, tn, ts);
                        break;
                };

                traditionalConfig = (traditionalConfig + 1) % 4;
                switch (traditionalConfig)
                {
                    case 0:
                        closeTrafficConfig(tetra, twtra, tntra, tstra);
                        bothOpen(tetra);
                        bothOpen(twtra);
                        break;
                    case 1:
                        closeTrafficConfig(tetra, twtra, tntra, tstra);
                        bothOpen(tntra);
                        bothOpen(tstra);
                        break;
                    case 2:
                        closeTrafficConfig(tetra, twtra, tntra, tstra);
                        middleClose(twtra);
                        middleClose(tetra);
                        break;
                    case 3:
                        closeTrafficConfig(tetra, twtra, tntra, tstra);
                        middleClose(tntra);
                        middleClose(tstra);
                        break;
                    default:
                        closeTrafficConfig(tetra, twtra, tntra, tstra);
                        break;

                };
                updatedTime = Time.realtimeSinceStartupAsDouble;
            }

        }

    }

    void openAll(BoxCollider traffic)
    {
        traffic.size = new Vector3(0f, 0f, 0f);
    }

    void closeTraffic(BoxCollider traffic1, BoxCollider traffic2, BoxCollider traffic3, BoxCollider traffic4)
    {
        close(traffic1);
        close(traffic2);
        close(traffic3);
        close(traffic4);

    }
    void middleClose(BoxCollider traffic)
    {
        traffic.size = new Vector3(1f, 1f, 2.36f);
        traffic.center = new Vector3(0, 0.5f, 0f);
    }
    void rightClose(BoxCollider traffic)
    {
        traffic.size = new Vector3(1f, 1f, 2.36f);
        traffic.center = new Vector3(0, 0.5f, 2.36f);
    }
    void bothClose(BoxCollider traffic)
    {
        traffic.size = new Vector3(1f, 1f, 4.72f);
        traffic.center = new Vector3(0, 0.5f, 1.18f);
    }
    void close(BoxCollider traffic)
    {
        traffic.size = new Vector3(1f, 1f, 7f);
        traffic.center = new Vector3(0, 0.5f, 0);
    }
    void leftOpen(BoxCollider traffic)
    {
        bothClose(traffic);
    }
    void bothOpen(BoxCollider traffic)
    {
        rightClose(traffic);
    }
    void closeTrafficConfig(BoxCollider traffic1, BoxCollider traffic2, BoxCollider traffic3, BoxCollider traffic4)
    {
        leftOpen(traffic1);
        leftOpen(traffic2);
        leftOpen(traffic3);
        leftOpen(traffic4);
    }
}
