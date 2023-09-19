using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _playerLifes = 4;
    public void decreaseLifes(int amount)
    {
        _playerLifes -= amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Missile"))
        {
            decreaseLifes(1);
            Destroy(collision.gameObject);
        }
    }
}
