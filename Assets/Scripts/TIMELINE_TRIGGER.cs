using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TIMELINE_TRIGGER : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<PlayableDirector>().Play();
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
