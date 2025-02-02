using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class Player : MonoBehaviour, IDamageable
{
    public static Player Instance { get; private set; }

    private HealthComponent _healthComponent;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("more than one player instance bruh");
        }
        Instance = this;

        _healthComponent = GetComponent<HealthComponent>();

    }


    public void Damage(float damageAmount)
    {
        this._healthComponent.Damage(damageAmount);
    }

}
