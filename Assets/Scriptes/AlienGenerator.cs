using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AlienGenerator : MonoBehaviour
{
  
    public List<GameObject> aliensPrefab;
    // Start is called before the first frame update
    void Start()
    {
       
            StartCoroutine(CreateAliens());
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private IEnumerator CreateAliens()
    {
        for (int i = 0; i < 10; i++)
            {
            int randomAlien = Random.Range(0, aliensPrefab.Count);

            yield return new WaitForSeconds(2f);
            CreateOneAlien(aliensPrefab[randomAlien]);
           
        }
        yield return new WaitForSeconds(2f);

    }

    public void CreateOneAlien(GameObject alienOne)
    {
          GameObject alien = Instantiate(alienOne);
           float rndX = Random.Range(0, 31);
            float rndY = Random.Range((float)12.7, (float)16.5);
            Vector2 randomVector = new Vector2(rndX, rndY);
             alien.transform.position = randomVector;
    }
  

}
