using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{

    
    [SerializeField] private float currentTimer = 0;

    private ObjectPooling linkedPool;
    public void LinkToPool(ObjectPooling pool)
    {
        linkedPool = pool;

    }

    private void OnEnable()
    {
        currentTimer = 0;
    }

    private void Update()
    {
        currentTimer += Time.deltaTime;
    }
}
