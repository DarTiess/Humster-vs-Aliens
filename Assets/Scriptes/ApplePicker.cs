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
       // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 positionPicker = transform.position;
         positionPicker.x += speedMove * Time.deltaTime;
         transform.position = positionPicker;

         if (positionPicker.x < -leftAndRightEdge)
         {
             speedMove = Mathf.Abs(speedMove);
         }else if(positionPicker.x > leftAndRightEdge*2)
         {
             speedMove = -Mathf.Abs(speedMove);
         }
    }
 
    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondApple);
    }
}
