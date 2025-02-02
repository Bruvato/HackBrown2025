using UnityEngine;
using UnityEngine.Pool;

public class ShootingComponent : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _projectileSpeed = 20f;

    private float _nextFireTime = 0f;


    //private IObjectPool<Projectile> _objectPool;

    //[SerializeField] private int _defaultCapacity;
    //[SerializeField] private int _maxSize;

    //[SerializeField] private bool _collectionCheck = true;


    private void Awake()
    {
        //_objectPool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, _collectionCheck, _defaultCapacity, _maxSize);
    }

    public void Shoot()
    {
        if (Time.time < _nextFireTime)
        {
            return;
        }

        if (_projectilePrefab == null || _firePoint == null)
        {
            Debug.LogError("bruh u didnt set projectile and fire point");
            return;
        }

        GameObject bullet = ObjectPool.Instance.GetPooledObject();
        bullet.SetActive(true);

        if (bullet != null)
        {
            bullet.transform.position = _firePoint.transform.position;
            bullet.transform.rotation = _firePoint.transform.rotation;

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * _projectileSpeed, ForceMode.Impulse);

            bullet.GetComponent<Projectile>().Deactivate();

        }



        //Projectile projectile = _objectPool.Get();

        //if (projectile == null)
        //{
        //    return;
        //}

        //projectile.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);

        //Rigidbody rb = projectile.GetComponent<Rigidbody>();
        //rb.AddForce(projectile.transform.forward * _projectileSpeed, ForceMode.Impulse);

        //projectile.Deactivate();

        _nextFireTime = Time.time + (1f / _fireRate);
    }






    //// invoked when creating an item to populate the object pool
    //private Projectile CreateProjectile()
    //{
    //    Projectile projectileInstance = Instantiate(_projectilePrefab);
    //    projectileInstance.ObjectPool = _objectPool;
    //    return projectileInstance;
    //}

    //private void OnGetFromPool(Projectile pooledObject)
    //{
    //    pooledObject.gameObject.SetActive(true);
    //}

    //private void OnReleaseToPool(Projectile pooledObject)
    //{
    //    pooledObject.gameObject.SetActive(false);
    //}

    //private void OnDestroyPooledObject(Projectile poolObject)
    //{
    //    Destroy(poolObject.gameObject);
    //}
}
