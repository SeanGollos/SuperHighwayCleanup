using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int maxInventory = 2; //Maximum inventory slots
    [SerializeField] int curInventory = 0; //Currently used inventory slots
    [SerializeField] AudioClip clip;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Trash>())
        {
            if(curInventory < maxInventory)
            {
                GetComponent<AudioSource>().PlayOneShot(clip);
                Destroy(otherCollider.gameObject);
                curInventory++;
                FindObjectOfType<InventoryDisplay>().UpdateDisplay();
            }
        }
    }

    public int GetCurInventory()
    {    return curInventory;    }

    public int GetMaxInventory()
    { return maxInventory; }

    public void EmptyInventory()
    {    curInventory = 0;       }
}
