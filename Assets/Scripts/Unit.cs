using UnityEngine;
using System.Collections.Generic;
using System;

public class Unit : MonoBehaviour
{
    private float unitHealth;
    public float unitMaxHealth;

    public HealthTracker healthTracker;

    void Start()
    {
        UnitSelectionManager.Instance.allUnitsList.Add(gameObject);

        unitHealth = unitMaxHealth;
        UpdateHealthUI();
    }

    private void OnDestroy()
    {
        UnitSelectionManager.Instance.allUnitsList.Remove(gameObject);
    }

    private void UpdateHealthUI()
    {
        healthTracker.UpdateSliderValue(unitHealth, unitMaxHealth);

        if (unitHealth <= 0)
        {
            // Handle unit death logic here, e.g., destroy the unit
            Destroy(gameObject);
        }
    }

    internal void TakeDamage(int damageToInflict)
    {
        unitHealth -= damageToInflict;
        UpdateHealthUI();
    }
}
