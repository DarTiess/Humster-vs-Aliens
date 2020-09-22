using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ApplePicker : MonoBehaviour
{
    public GameObject laserPrefab;
    public float speedMove = 1.0f;
    
    public Sprite spriteAttacked;
    public Sprite spriteNormal;

    public float secondApple;
    public float aliensLifes=10f;
       // Start is called before the first frame update
    void Start()
    {
        Invoke("DropLaser", 2f);
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 positionPicker = transform.position;
         positionPicker.x += speedMove * Time.deltaTime;
         transform.position = positionPicker;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if (positionPicker.x < min.x)
         {
             speedMove = Mathf.Abs(speedMove);
         }
        else if(positionPicker.x > max.x)
         {
             speedMove = -Mathf.Abs(speedMove);
         }

        
       
    }
 
    void DropLaser()
    {
        GameObject laser = Instantiate(laserPrefab);
        laser.transform.position = transform.position;
        Invoke("DropLaser", secondApple);
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
        if (aliensLifes > 0) { 
        aliensLifes--;
        this.GetComponent<SpriteRenderer>().sprite = spriteAttacked;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = spriteNormal;
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<SpriteRenderer>().sprite = spriteAttacked;
        yield return new WaitForSeconds(0.2f);
        this.GetComponent<SpriteRenderer>().sprite = spriteNormal;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
   
    


}
