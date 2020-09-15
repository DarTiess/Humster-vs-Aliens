using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Steps;

public class AppleShooter : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject applesGameObject;
    public Text appleScore;
    public GameObject pushPoint;
    public Transform EnemyPosition;
    public FixedButton PushAppleButton;
    private Rigidbody2D homa;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
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
        applesGameObject.transform.position = pushPoint.transform.position;
       appleScore.text = (apples - 1).ToString(); 
      
    }

    public void AppleAttack()
    {
       
        GameObject readyApple = Instantiate(applePrefab,pushPoint.transform.position, rotation: Quaternion.identity) as GameObject;
        readyApple.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(pushPoint.transform.up * 15f);
        readyApple.transform.up = pushPoint.transform.up;
    }

    
}
