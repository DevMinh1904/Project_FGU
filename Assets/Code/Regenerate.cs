using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Regenerate : MonoBehaviour
{
    [Header("Attribute")]
    [SerializeField] private int maxHitPoints = 10;
    [SerializeField] private int regenAmount = 2;
    [SerializeField] private float regenInterval = 1.0f;

    private Heath heath;

    private void Start()
    {
        heath = GetComponent<Heath>();

        if (heath != null)
        {
            StartCoroutine(RegenerateHealth());
        }
        else
        {
            Debug.LogError("Regenerate script: Missing Heath component!");
        }
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenInterval);

            if (heath == null || heath.IsDestroyed()) break;

            int currentHP = heath.GetHitPoints();

            if (currentHP < maxHitPoints)
            {
                int healAmount = Mathf.Min(regenAmount, maxHitPoints - currentHP);
                heath.Heal(healAmount);
                Debug.Log($"Enemy regenerates to {heath.GetHitPoints()} HP");
            }
        }
    }

}
