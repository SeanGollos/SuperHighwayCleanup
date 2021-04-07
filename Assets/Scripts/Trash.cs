using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    private void Awake()
    {
        FindObjectOfType<LevelController>().TrashDropped();
    }
}
