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
            string[] destinations = { "W1'N", "W2'N", "W3'N",
                                      "N1'N", "N2'N", "N3'N",
                                      "E1'N", "E2'N", "E3'N",
                                      "S1'N", "S2'N", "S3'N" };
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
