using UnityEngine;

[DisallowMultipleComponent]
public abstract class AEngine : MonoBehaviour {
    public float Power { get; set; }

    public abstract void Move();
}
