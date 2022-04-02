using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemUnlock : MonoBehaviour
{
    public GameObject UnlockSprite;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UnlockSprite.SetActive(true);
            Destroy(gameObject);
        }

    }
}
