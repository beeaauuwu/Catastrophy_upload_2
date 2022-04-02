using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUi : MonoBehaviour
{
    private TextMeshProUGUI SoulText;
    // Start is called before the first frame update
    void Start()
    {
        SoulText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateSoulText(PlayerInventory playerInventory)
    {
        SoulText.text = playerInventory.NumberSouls.ToString();
    }
}
