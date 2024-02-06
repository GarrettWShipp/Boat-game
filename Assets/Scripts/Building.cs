using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public GameObject BuilderPos;
    public GameObject Material;
    public Transform Blueprint;



    // Update is called once per frame
    void Update()
    {
        //Builder Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.forward;
        }

        if (Input.GetKeyDown((KeyCode.S)))
        {
            transform.position += Vector3.back;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            transform.position += Vector3.down;
        }

        //Creating game object and putting it in blueprint parent

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Material, transform.position, Quaternion.identity, Blueprint);
        }
    }
}

