using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAbility : MonoBehaviour
{
    [SerializeField] private Transform weaponTip;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private float shootingForce;

    ObjectPooling objectPoolingCache; //Could add Serialize Field here

    private void Awake()
    {
        objectPoolingCache = FindObjectOfType<ObjectPooling>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (objectPoolingCache == null) return;

        Rigidbody clonedRigidbody = FindObjectOfType<ObjectPooling>().RetrieveAvailableBullet().GetRigidbody();

        clonedRigidbody.position = weaponTip.position;
        clonedRigidbody.rotation = weaponTip.rotation;

        clonedRigidbody.AddForce(weaponTip.forward * shootingForce);
    }
}
