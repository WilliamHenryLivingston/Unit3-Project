using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private int amountOfClones = 20;
    [SerializeField] private List<Rigidbody> availableBullets;
    [SerializeField] private List<Rigidbody> unavailableBullets;


    void Start()
    {
        int currentAmountofClones = 0;
        while(currentAmountofClones < amountOfClones)
        {
            AddElementToPool();
            currentAmountofClones++;
        }

    }

    void AddElementToPool()
    {
        Rigidbody clone = Instantiate(bulletPrefab);

        clone.gameObject.SetActive(false);
        clone.transform.SetParent(transform);
        availableBullets.Add(clone);

    }

    public Rigidbody RetrieveAvailableBullet()
    {
        if (availableBullets.Count == 0)
        {
            AddElementToPool();
        }
        Rigidbody firstAvailable = availableBullets[0];

        availableBullets.RemoveAt(0);
        unavailableBullets.Add(firstAvailable);

        firstAvailable.gameObject.SetActive(true);
        StartCoroutine(ResetBullet(firstAvailable));
        return firstAvailable;
    }

    IEnumerator ResetBullet(Rigidbody bulletToReset)
    {
        yield return new WaitForSeconds(5f);

        unavailableBullets.Remove(bulletToReset);
        bulletToReset.gameObject.SetActive(false);
        bulletToReset.velocity = Vector3.zero;
        availableBullets.Add(bulletToReset);
    }
}
