using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class players : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;
    GameObject currentfloor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(movespeed * Time.deltaTime, 0, 0);

        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-movespeed * Time.deltaTime, 0, 0);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "floor")
        {
            Debug.Log("這階梯");
            currentfloor = other.gameObject;
        }
        else if (other.gameObject.tag == "lava")
        {
            Debug.Log("岩漿");
            currentfloor = other.gameObject;
        }
        else if (other.gameObject.tag == "tenjio")
        {
            Debug.Log("天花板");
            currentfloor.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "deadline")
        {
            Debug.Log("GG");
        }
    }
}
