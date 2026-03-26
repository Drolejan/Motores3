using System;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private float maxStamina = 5f;
    [SerializeField] private float currentStamina = 5f;
    [SerializeField] private float staminaDrain = 1f;
    [SerializeField] private float staminaRecovery = 0.5f;
    bool sprintLock=false;
    private float minStamina=1.5f;//Stamina minima para correr

    public float CurrentStamina => currentStamina;//Funcion que permite SOLO leer una variable privada
    public float MaxStamina => maxStamina;

    public bool CanSprint()
    {
        return sprintLock==false && currentStamina > 0f;
    }

    public void DrainStamina()
    {
        currentStamina -= staminaDrain * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        if (currentStamina <= 0)
        {
            sprintLock=true;
        }

        NotifyStamina();
    }

    public void JumpDrain()
    {
        currentStamina -= staminaDrain/2;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);
        if (currentStamina <= 0)
        {
            sprintLock=true;
        }
        NotifyStamina();
    }

    public void RecoverStamina()
    {
        currentStamina += staminaRecovery * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0f, maxStamina);

        if (currentStamina > minStamina)
        {
            sprintLock=false;
        }

        NotifyStamina();
    }

    //EVENTO
    public event Action<float> OnStaminaChanged;

    private void NotifyStamina()
    {
        OnStaminaChanged?.Invoke(currentStamina);
    }
}
