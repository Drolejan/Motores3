using UnityEngine;
using UnityEngine.UI;

public class StaminaBarUI : MonoBehaviour
{
    [SerializeField] private Image staminaFillImage;
    private PlayerStamina playerStamina;

    private void Start()
    {
        playerStamina = FindFirstObjectByType<PlayerStamina>();
        //Uso de eventos: Vamos a suscribir la función Update stamina a la funcion OnStaminaChanged
        playerStamina.OnStaminaChanged += UpdateStaminaBar;
    }

    void OnDestroy()
    {
        playerStamina.OnStaminaChanged -= UpdateStaminaBar;        
    }


    private void UpdateStaminaBar(float currentStamina)
    {
        staminaFillImage.fillAmount = currentStamina / playerStamina.MaxStamina;
    }
}