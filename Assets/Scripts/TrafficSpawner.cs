using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] float vehicleSpeed = 200f;
    [SerializeField] Vehicle[] vehiclePrefabs;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnVehicle();
        }
    }

    private void SpawnVehicle()
    {
        Vehicle chosenVehicle;
        chosenVehicle = vehiclePrefabs[Random.Range(0, vehiclePrefabs.Length)]; //Pick a random vehicle from the array
        Spawn(chosenVehicle);
    }
    private void Spawn(Vehicle vehicle)
    {
        Vehicle newVehicle = Instantiate(vehicle, transform.position, transform.rotation) as Vehicle;

        newVehicle.transform.parent = transform;
    }

    public float SetSpeed()
        {
            return vehicleSpeed;
        }
}
