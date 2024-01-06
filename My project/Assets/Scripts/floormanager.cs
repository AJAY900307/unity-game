using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floormanager : MonoBehaviour
{
    [SerializeField] GameObject[] FloorPrefabs;



    public void SpawnFloor()
    {
        int r = Random.Range(0, FloorPrefabs.Length);
        GameObject floor = Instantiate(FloorPrefabs[r], transform);
        floor.transform.position = new Vector3(Random.Range(-4.6f, 7.1f), Random.Range(-6f, -7f), 0f);
    }
}
