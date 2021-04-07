using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTruck : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    LevelController lc;
    Inventory inventory;
    InventoryDisplay id;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        lc = FindObjectOfType<LevelController>();
        inventory = FindObjectOfType<Inventory>();
        id = FindObjectOfType<InventoryDisplay>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<Player>())
        {
            lc.TrashPickedUp(inventory.GetCurInventory());
            if (inventory.GetCurInventory() > 0)
            {
                anim.SetTrigger("Crush");
                GetComponent<AudioSource>().PlayOneShot(clip);
            }
            inventory.EmptyInventory();
            id.UpdateDisplay();
        }
    }
}
