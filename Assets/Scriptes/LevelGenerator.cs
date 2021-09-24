using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    public List<LevelPiece> levelsPrefabs = new List<LevelPiece>();
    public Transform levelStartPoint;
    public List<LevelPiece> piecesExisting = new List<LevelPiece>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GenerateInitialPiece();
    }
    public void GenerateInitialPiece()
    {
        for(int i = 0; i < 2; i++)
        {
            AddPiece();
        }
    }

    public void AddPiece()
    {
        int randomIndexOfPiece = Random.Range(0, levelsPrefabs.Count);
        LevelPiece piece = (LevelPiece)Instantiate(levelsPrefabs[randomIndexOfPiece]);
        piece.transform.SetParent(this.transform, false);
        Vector3 spawnPosition;

        if (piecesExisting.Count == 0)
        {
            spawnPosition = levelStartPoint.position;
        }
        else
        {
            piece.startPoint.position = piecesExisting[piecesExisting.Count-1].endPoint.position;
            spawnPosition = piece.startPoint.position;
        }
        piece.transform.position = piece.startPoint.position;
        piecesExisting.Add(piece);
    }

    public void RemoveOldPiece()
    {
        LevelPiece oldestPiece = piecesExisting[0];

        piecesExisting.Remove(oldestPiece);
        Destroy(oldestPiece.gameObject);
    }
}
