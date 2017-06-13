using UnityEngine;
using System.Collections;
using System;

public class Turret : MonoBehaviour
{
    // Specific Gun properties
    private GunProperties gunProperties;

    // ReloadingStatus
    private Boolean reloading;

    Transform turretTransform;

    // Amount of ammo left
    private int clipRemaining;

    // The type of Gun Behaviour
    public IWeaponBehaviour behaviour;

    // The time at which reload was initiated
    private float timeAtReloadStarted;

    private void StartReload()
    {
        reloading = true;
        timeAtReloadStarted = Time.time;
    }

    // Use this for initialization
    void Start(IWeaponBehaviour behaviour, GunProperties properties)
    {
        this.behaviour = behaviour;
        gunProperties = properties;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        behaviour.OnHit(col, gunProperties.damage);
    }

    public void Shoot()
    {
        // Check if Gun is reloading
        if (reloading) return;
        // Check if any ammo left
        if (clipRemaining <= 0)
        {
            StartReload();
            return;
        }
        // Activate gun behaviour
        behaviour.Activate(turretTransform);
        // Decrease ammo in Clip
        clipRemaining--;
    }
    
    private void FinishReload()
    {
        reloading = false;
        clipRemaining = gunProperties.clipSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading)
        {
            if ((Time.time - timeAtReloadStarted) > gunProperties.reloadTime)
            {
                FinishReload();
            }
        }
    }
}

// Specific Gun properties
struct GunProperties
{
    public int reloadTime;
    //public int coolDown;
    public int clipSize;
    public int damage;
}

public abstract class WeaponBehaviour : IWeaponBehaviour
{
    private void SetPosition(GameObject gameObject, Transform transform)
    {
        gameObject.transform.position = transform.position;
        gameObject.transform.rotation = transform.rotation;
    }

    // On hit add damage
    public abstract void OnHit(Collision2D collidedObject, int damage);

    public abstract void Activate(Transform transform);

    public void ActivateBehaviour(Transform transform, String tag)
    {
        GameObject gameObject = ObjectPool.getInstance().GetPooledObject(tag);

        if (gameObject != null)
        {
            SetPosition(gameObject, transform);
            gameObject.SetActive(true);
        }
    }
}

public class BulletBehaviour : WeaponBehaviour
{
    public override void Activate(Transform transform)
    {
        ActivateBehaviour(transform, "Bullet");
    }

    // Bullet does damage to health
    public override void OnHit(Collision2D collidedObject, int damage)
    {
            collidedObject.gameObject.GetComponent<Health>().ShipHealth -= damage;
    }
}

public class ShieldBehaviour : WeaponBehaviour
{
    public override void Activate(Transform transform)
    {
        ActivateBehaviour(transform, "Shield");
    }

    // Shield does no damage
    public override void OnHit(Collision2D collidedObject, int damage)
    {
        throw new NotImplementedException();
    }
}

public class LaserBehaviour : WeaponBehaviour
{
    public override void Activate(Transform transform)
    {
        ActivateBehaviour(transform, "Laser");
    }

    // Laser does damage to Shield
    public override void OnHit(Collision2D collidedObject, int damage)
    {
            collidedObject.gameObject.GetComponent<Shield>().ShieldResistance -= damage;
    }
}

// The type of Gun Behaviour
public interface IWeaponBehaviour
{
    void Activate(Transform tranform);
    void OnHit(Collision2D collidedObject, int damage);
}
