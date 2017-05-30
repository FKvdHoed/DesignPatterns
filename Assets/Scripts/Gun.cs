using UnityEngine;
using System.Collections;
using System;

public class Gun : MonoBehaviour
{
    // Specific Gun properties
    private GunProperties gunProperties;

    // ReloadingStatus
    private Boolean reloading;

    // Amount of ammo left
    private int clipRemaining;

    // The type of Gun Behaviour
    public IFireBehaviour behaviour;

    // The time at which reload was initiated
    private float timeAtReloadStarted;

    private void StartReload()
    {
        reloading = true;
        timeAtReloadStarted = Time.time;
    }

    // Use this for initialization
    void Start(IFireBehaviour behaviour, GunProperties properties)
    {
        this.behaviour = behaviour;
        gunProperties = properties;
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
        behaviour.Activate();
        // Decrease ammo in Clip
        clipRemaining--;
    }

    // Specific Gun properties
    struct GunProperties
    {
        public int reloadTime;
        //public int coolDown;
        public int clipSize;
        public int damage;
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

public class Bullet : IFireBehaviour
{
    void IFireBehaviour.Activate()
    {
    }
}

public class Shield : IFireBehaviour
{
    void IFireBehaviour.Activate()
    {

    }
}

public class Laser : IFireBehaviour
{
    void IFireBehaviour.Activate()
    {
    }
}

// The type of Gun Behaviour
public interface IFireBehaviour
{
    void Activate();
}
