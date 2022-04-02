using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepOnMe : MonoBehaviour
{
    public Material CorrectMaterial;
    public Material WrongMaterial;
    public bool[] CorrectTiles = new bool[4]; 
    public Material RegularMaterial;
    public static StepOnMe Instance;
    public GameObject Bridge;
    public bool Completed;
    public GameObject ResetLocation;
    public List<GameObject> TileList = new List<GameObject>();
    public bool IsResetting;
    private void Awake()
    {
        Instance = this;
    }
    public void ChangeSelectedTile(bool Correct, int Row, GameObject Tile, GameObject player)
    {
        if (Correct)
        {
            Tile.GetComponent<MeshRenderer>().material = CorrectMaterial;
            CorrectTiles[Row] = true;
            CheckCompletion();
        }
        else
        {
            Tile.GetComponent<MeshRenderer>().material = WrongMaterial;
            StartCoroutine(StartReset(player));
        }
    }
    IEnumerator StartReset(GameObject player)
    {
        IsResetting = true;
        yield return new WaitForSeconds(3);
        ResetPuzzle(player);
    }
    public void ResetPuzzle(GameObject player)
    {
        foreach(GameObject tile in TileList)
        {
            tile.GetComponent<MeshRenderer>().material = RegularMaterial;
        }
        CorrectTiles = new bool[4];
        IsResetting = false;
    }
    public void CheckCompletion()
    {
        int Index = 0;
        for (int i = 0; i < CorrectTiles.Length; i++)
        {
           if (CorrectTiles[i] == true)
            {
                Index++;
            }
        } 
        if(Index == 4)
        {
            Completed = true;
            Bridge.SetActive(true);
        }
    }
}
