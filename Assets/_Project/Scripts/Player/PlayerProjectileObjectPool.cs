using com.digitalmind.towertest;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerProjectileObjectPool : MonoBehaviour
{
    public ObjectPool<PlayerProjectile> projectilePool;
    public PlayerProjectile projectilePrefab;

    private void Awake()
    {
        projectilePool = new ObjectPool<PlayerProjectile>(
            CreateProjectile,
            OnGetProjectile,
            OnReleaseProjectile,
            OnDestroyProjectile);
    }
    
    public PlayerProjectile CreateProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform);
        projectile.transform.position = transform.position;
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