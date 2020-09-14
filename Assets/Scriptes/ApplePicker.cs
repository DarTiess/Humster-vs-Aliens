using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject applePrefab;
    public float speedMove = 1.0f;
    public float leftAndRightEdge;
    public GameObject targetHoma;

    public float secondApple;
    float chanceTochange = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {

      
     //  transform.RotateAround(targetHoma.transform.position, Vector2.up, 35 * Time.deltaTime);
         Vector3 positionPicker = transform.position;
         positionPicker.x += speedMove * Time.deltaTime;
         transform.position = positionPicker;

         if (positionPicker.x < -leftAndRightEdge)
         {
             speedMove = Mathf.Abs(speedMove);
         }else if(positionPicker.x > leftAndRightEdge)
         {
             speedMove = -Mathf.Abs(speedMove);
         }
    }
    private void FixedUpdate()
    {
        if (Random.value < chanceTochange)
        {
            speedMove *= -1;
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondApple);
    }
}
