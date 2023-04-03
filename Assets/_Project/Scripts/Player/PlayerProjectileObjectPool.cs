using com.digitalmind.towertest;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerProjectileObjectPool : MonoBehaviour
{
    private ObjectPool<PlayerProjectile> _projectilePool;
    public PlayerProjectile projectilePrefab;

    private void Awake()
    {
        _projectilePool = new ObjectPool<PlayerProjectile>(
            CreateProjectile,
            OnGetProjectile,
            OnReleaseProjectile,
            OnDestroyProjectile);
    }

    public PlayerProjectile Get() => _projectilePool.Get();
    public void Release(PlayerProjectile projectile) => _projectilePool.Release(projectile);

    public PlayerProjectile CreateProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform);
        projectile.transform.position = transform.position;
        projectile.projectilePool = this;
        return projectile;
    }

    public void OnGetProjectile(PlayerProjectile projectile)
    {
        projectile.gameObject.SetActive(true);
    }
    
    public void OnReleaseProjectile(PlayerProjectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectile.transform.position = transform.position;
    }
    
    public void OnDestroyProjectile(PlayerProjectile projectile)
    {
        Destroy(projectile.gameObject);
    }
}