using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    private Transform ThisTransform = null;
    public GameObject objPrefab = null;
    public int PoolSize = 10;
    private void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

    // Use this for initialization
    void Start()
    {
        GeneratePool();
    }

    public void GeneratePool()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject obj = Instantiate(objPrefab, Vector3.zero, Quaternion.identity, ThisTransform);
            obj.SetActive(false);
        }
    }

    public Transform Spawn(Transform parent,
        Vector3 pos = new Vector3(),
        Quaternion rot = new Quaternion(),
        Vector3 scale = new Vector3())
    {
        Debug.Log("ObjectPool.Spawn");

        if (ThisTransform.childCount <= 0) return null;

        Transform child = ThisTransform.GetChild(0);

        child.SetParent(parent);
        child.position = pos;
        child.rotation = rot;
        child.localScale = scale;
        NormalSize(child);
        child.gameObject.SetActive(true);
        return child;
    }

    public void Despawn(Transform obj)
    {
        obj.gameObject.SetActive(false);
        obj.SetParent(ThisTransform);
        obj.position = Vector3.zero;
    }

    public void NormalSize(Transform obj)
    {
        obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

}
