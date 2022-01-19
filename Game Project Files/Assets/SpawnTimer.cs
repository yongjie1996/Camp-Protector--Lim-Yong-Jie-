using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimer : MonoBehaviour
{

    public string SpawnPoolTag = string.Empty;
    public float SpawnDelay = 2f;
    public float SpawnInterval = 5f;

    private ObjectPool pool = null;

    private void Awake()
    {
        pool = GameObject.FindWithTag(SpawnPoolTag).GetComponent<ObjectPool>();
    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", SpawnDelay, SpawnInterval);
    }

    // Update is called once per frame
    public void Spawn()
    {
        pool.Spawn(null, transform.position, transform.rotation, Vector3.one);
    }
}
