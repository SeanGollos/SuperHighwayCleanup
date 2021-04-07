using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] float speed = 200f;

    private void Start()
    {
        speed = GetComponentInParent<TrafficSpawner>().SetSpeed();
    }
    private void Update()
    {   
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
