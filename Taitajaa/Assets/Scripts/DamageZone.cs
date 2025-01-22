using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    [SerializeField] float timeOn = 5f;
    [SerializeField] float damage = 10f;

    private void Update()
    {
        if (timeOn <= 0)
        {
            PlayerController.instance.Increasecoins(1);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeOn -= Time.deltaTime;
            PlayerController.instance.TakeDamage(damage);
        }
    }
}
