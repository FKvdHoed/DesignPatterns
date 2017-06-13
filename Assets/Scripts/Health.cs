using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int ShipHealth { get; set; }

    private static int sMaxHealth = 100;
    private SpriteRenderer _healthBar;
    private Vector3 _healthScale;

    // Use this for initialization
    void Start()
    {
        ShipHealth = sMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        // Set the health bar's colour to proportion of the way between green and red based on the player's health.
        _healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - ShipHealth * 0.01f);

        // Set the scale of the health bar to be proportional to the player's health.
        _healthBar.transform.localScale = new Vector3(_healthScale.x * ShipHealth * 0.01f, 2, 1);
    }
}
