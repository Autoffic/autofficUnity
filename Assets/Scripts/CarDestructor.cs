using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Destroy(other.gameObject);
        }
    }
}
