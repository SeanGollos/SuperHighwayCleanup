using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Text inventoryText;
    Inventory inventory;
    string cur;
    string max;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        inventoryText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        cur = inventory.GetCurInventory().ToString();
        max = inventory.GetMaxInventory().ToString();

        inventoryText.text = cur + "/" + max;
    }
}
