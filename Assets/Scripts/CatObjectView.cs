using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatObjectView : MonoBehaviour

{
    public void ShowGameobject(bool DoShow)
    {
        gameObject.SetActive(DoShow);
    }
}
