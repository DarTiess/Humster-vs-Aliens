using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    public static float bottomY = -20f;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(transform.up * 15f);
          /*  Vector3 positionPicker = transform.position;
            positionPicker.z -= 10f * Time.deltaTime;
            transform.position = positionPicker;
          */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(transform.up * 15f);
        }
    }


}
