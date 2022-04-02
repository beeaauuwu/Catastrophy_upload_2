using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    public bool CorrectTile;

    public int Row;
    private void Start()
    {
        StepOnMe.Instance.TileList.Add(this.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")&& !StepOnMe.Instance.Completed &&!StepOnMe.Instance.IsResetting)
        {
            StepOnMe.Instance.ChangeSelectedTile(CorrectTile, Row, this.gameObject, collision.gameObject);
        }
    }
}
