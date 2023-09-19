using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private ParticleSystem _crashingMissile;
    [SerializeField] private GameObject _gameObjectMissile;
    [SerializeField] private Collider _missileCollider;

    private Player _playerCol;
    private Rigidbody _missileRigidBody;

    private void Start()
    {
        _missileRigidBody = GetComponent<Rigidbody>();
        StartCoroutine(deletingMissile(5));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerHead"))
        {
            _playerCol = collision.gameObject.GetComponent<Player>();
            _playerCol.decreaseLifes(1);
            _missileRigidBody.isKinematic = true;
            _crashingMissile.Play();
            Destroy(_gameObjectMissile);
            _missileCollider.isTrigger = true;
            StartCoroutine(deletingMissile(3));
        }
        else if (collision.gameObject.CompareTag("GroundEarth"))
        {

            _missileRigidBody.isKinematic = true;
            _crashingMissile.Play();
            Destroy(_gameObjectMissile);
            _missileCollider.isTrigger = true;
            StartCoroutine(deletingMissile(3));
        }
    }

    IEnumerator deletingMissile(int time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
