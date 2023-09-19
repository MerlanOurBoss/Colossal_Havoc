using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Animation _cannonAnimator;
    [SerializeField] private Transform _playerTrans;
    [SerializeField] private Rigidbody _bulletRigid;
    [SerializeField] private Transform _bulletSpawner;
    [SerializeField] private ParticleSystem _shootingCannon;
    [SerializeField] private AudioSource _cannonShoutingSound;
    [SerializeField] private AudioSource _cannonDeathSound;

    [SerializeField] private int _missileSpeed;
    [SerializeField] private int _missileShootingTime;
    [SerializeField] private ParticleSystem _destroingPrefab;

    private int _healthCannon = 100;

    private bool isShoot = false;

    private void Start()
    {
        StartCoroutine(cannonShoot(_missileShootingTime));
    }

    private void Update()
    {
        if (_healthCannon < 1)
        {
            _cannonDeathSound.Play();
            _destroingPrefab.Play();
            Destroy(gameObject);
        }
        RaycastHit _hit;
        Vector3 distance = this.transform.position - _playerTrans.transform.position;
        distance.y = 0;
        if (Physics.Linecast(this.transform.position, _playerTrans.transform.position, out _hit, -1))
        {
            if (_hit.transform.CompareTag("PlayerHead"))
            {
                if (distance.magnitude > 100)
                {
                    //this.transform.Translate(Vector3.forward * 2f * Time.deltaTime);
                    this.transform.LookAt(_playerTrans.transform);
                    isShoot = false;
                }
                else
                {
                    isShoot = true;                    
                    this.transform.LookAt(_playerTrans.transform);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _healthCannon--;
        }
    }
    IEnumerator cannonShoot(int time)
    {
        yield return new WaitForSeconds (time);
        if (isShoot)
        {
            
            Rigidbody clone = Instantiate(_bulletRigid, _bulletSpawner.transform.position, Quaternion.identity);
            clone.velocity = _bulletSpawner.TransformDirection(Vector3.forward * _missileSpeed * Time.deltaTime);
            _shootingCannon.Play();
            _cannonShoutingSound.Play();
            _cannonAnimator.Play();
        }
        StartCoroutine(cannonShoot(time));
    }
}
