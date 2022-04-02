using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelOneManager : MonoBehaviour
{
    public string LevelName;
    public Image TransitionScreen;
    public AudioSource FadeAudio;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TransitionLevel());
        }
    }
    IEnumerator TransitionLevel()
    {
        while (TransitionScreen.color.a < 1f)
        {
            var TempColor = TransitionScreen.color;
            TempColor.a += 0.1f;
            FadeAudio.volume -= 0.1f;
            TransitionScreen.color = TempColor;
            yield return new WaitForSeconds(0.2f);
        }
         SceneManager.LoadScene(LevelName);
    }

}
