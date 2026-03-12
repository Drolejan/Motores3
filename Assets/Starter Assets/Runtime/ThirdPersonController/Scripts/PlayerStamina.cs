using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private float maxStamina = 5f;
    [SerializeField] private float currentStamina = 5f;
    [SerializeField] private float staminaDrain = 1f;
    [SerializeField] private float staminaRecovery = 0.5f;

    public float CurrentStamina => currentStamina;//Funcion que permite SOLO leer una variable privada
    public float MaxStamina => maxStamina;

    public bool CanSprint()
    {
        return currentStamina > 0f;
    }

    public void DrainStamina()
    {
        currentStamina -= staminaDrain * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }

    public void RecoverStamina()
    {
        currentStamina += staminaRecovery * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
    }
}
