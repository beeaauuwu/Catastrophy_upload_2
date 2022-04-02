using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberSouls { get; private set; }
    public UnityEvent<PlayerInventory> OnSoulCollection;
    public GameObject LockedDoor;
    public void NumberSoulsCollected()
    {
        NumberSouls++;
        OnSoulCollection.Invoke(this);
    }
    public void Update()
    {
        if(NumberSouls>= 30)
            {
            Destroy(LockedDoor);
        }
    }
}
