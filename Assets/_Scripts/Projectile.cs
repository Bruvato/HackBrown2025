using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _damageAmount;

    [SerializeField] private float _timeoutDelay = 2f;

    //private IObjectPool<Projectile> _objectPool;

    //public IObjectPool<Projectile> ObjectPool { set =>  _objectPool = value; }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(_timeoutDelay));
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        Reset();


    }

    private void Reset()
    {
        gameObject.SetActive(false);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.Damage(_damageAmount);
            Reset();
        }

    }
}
