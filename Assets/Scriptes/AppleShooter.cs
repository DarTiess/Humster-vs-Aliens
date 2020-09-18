using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Steps;

public class AppleShooter : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject applesGameObject;
    public Text appleScore;
    public List<GameObject> pushPoint;
    public Transform EnemyPosition;
    public FixedButton PushAppleButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /*  Quaternion rotation = Quaternion.LookRotation(EnemyPosition.position - pushPoint.transform.position);
         pushPoint.transform.rotation = rotation;
       */
        if (PushAppleButton.Pressed)
        {
            PushApple();
        }
    }


     public void AddApple()
    {
        int apples = int.Parse(appleScore.text);
        if (apples < 5) 
        { 
            appleScore.text = (apples + 1).ToString();
        }
      
    }

    public void PushApple()
    {
        int apples = int.Parse(appleScore.text);
        applesGameObject= Instantiate(applePrefab);
        applesGameObject.transform.position = transform.position;
       appleScore.text = (apples - 1).ToString(); 
      
    }

    public void AppleAttack()
    {
         foreach( GameObject point in pushPoint)
        {
         GameObject readyApple = Instantiate(applePrefab,point.transform.position, rotation: Quaternion.identity) as GameObject;
       

        readyApple.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(point.transform.up * 15f);
        }
       
      
    }

  

    
}
