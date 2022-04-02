using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject[] cat;
    public GameObject[] bird;
    public Vector3 currentposition;
    private bool catactive;
    public Quaternion currentrotation;
    public GameObject effect;
    [SerializeField] List<GameObject> CatObject = new List<GameObject>();
    private void Awake ()
    {
        catactive = false;
        foreach (CatObjectView CatView in FindObjectsOfType<CatObjectView>())
        {
            CatObject.Add(CatView.gameObject);
            CatView.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cat[0].activeSelf)
            {
                currentposition = cat[0].transform.position;
                catactive = true;
                currentrotation = cat[0].transform.rotation;
            }
            else
            {
                currentposition = bird[0].transform.position;
                catactive = false;
                currentrotation = bird[0].transform.rotation;
            }
            for(int i = 0; i < cat.Length; i++)
            {
                if (i == 0)
                {
                    if (catactive)
                    {
                        GameObject tempeffect = Instantiate(effect);
                        tempeffect.transform.position = currentposition;
                        bird[i].transform.position = currentposition;
                        bird[i].transform.rotation = currentrotation;
                        StartCoroutine(destroyeffect(tempeffect));
                    }
                    else
                    {
                        GameObject tempeffect = Instantiate(effect);
                        tempeffect.transform.position = currentposition;
                        cat[i].transform.position = currentposition;
                        cat[i].transform.rotation = currentrotation;
                        StartCoroutine(destroyeffect(tempeffect));
                    }
                }
                cat[i].SetActive(!cat[i].activeSelf);
                bird[i].SetActive(!bird[i].activeSelf);
            }
            for(int i = 0; i < CatObject.Count; i++)
            {
                CatObject[i].SetActive(!catactive);
            }
        }
    }
    IEnumerator destroyeffect(GameObject spawneffect)
    {
        yield return new WaitForSeconds(3);
        Destroy(spawneffect);
    }

}
