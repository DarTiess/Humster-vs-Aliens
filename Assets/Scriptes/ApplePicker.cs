using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject laserPrefab;
    public float speedMove = 1.0f;
    public float leftAndRightEdge;
    
    public Sprite spriteAttacked;
    public Sprite spriteNormal;

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
        GameObject laser = Instantiate(laserPrefab);
        laser.transform.position = transform.position;
        Invoke("DropApple", secondApple);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "apple")
        {
            StartCoroutine(TakeDamage());
        }
    }
    private IEnumerator TakeDamage()
    {
        this.GetComponent<SpriteRenderer>().sprite = spriteAttacked;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = spriteNormal;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = spriteAttacked;
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<SpriteRenderer>().sprite = spriteNormal;
    }
   
    


}
