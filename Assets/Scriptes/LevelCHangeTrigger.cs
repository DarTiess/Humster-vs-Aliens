using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCHangeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LevelGenerator.instance.AddPiece();
            LevelGenerator.instance.RemoveOldPiece();
        }
    }
   
}
