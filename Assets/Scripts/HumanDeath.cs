using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanDeath : MonoBehaviour
{
    [SerializeField] private GameObject _humanGameObject;
    [SerializeField] private Transform _humanDeathPlace;
    [SerializeField] private GameObject _humanDeathPrefab;
    [SerializeField] private AudioSource _humanDeathSound;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GroundEarth"))
        {
            _humanDeathSound.Play();
            Instantiate(_humanDeathPrefab, _humanDeathPlace.position, Quaternion.identity);
            Destroy(_humanGameObject);
        }

    }
}
