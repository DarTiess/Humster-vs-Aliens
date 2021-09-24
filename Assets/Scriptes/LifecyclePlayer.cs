using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifecyclePlayer : MonoBehaviour
{

    public Text lifeScore;
    private int lifes;
   
    // Start is called before the first frame update
    void Start()
    {
        lifes = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        lifeScore.text = "lifes: "+ (lifes - 1).ToString();
    }
    
}
