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
         for(int j = 0; j < 3; j++)
        {
            StartCoroutine(CreateAliens());
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private IEnumerator CreateAliens()
    {
        for (int i = 0; i < aliensPrefab.Count; i++)
            {

            yield return new WaitForSeconds(2f);
            CreateOneAlien(aliensPrefab[i]);
           
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
