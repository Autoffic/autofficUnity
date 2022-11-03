using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarDestructor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("collided");
        if (other.gameObject.tag == "cars")
        {
            var destination = other.gameObject.GetComponent<NavMeshAgent>().destination;
            string[] destinations = { "W1'", "W2'", "W3'",
                                      "N1'", "N2'", "N3'",
                                      "E1'", "E2'", "E3'",
                                      "S1'", "S2'", "S3'" };
            var no = 0;
            foreach (string desti in destinations)
            {
                if (destination == GameObject.Find(desti).gameObject.transform.position)
                {
                    SocketClient.carNo[no]--;
                }
                no++;
            }
            Destroy(other.gameObject);
        }
    }
}
