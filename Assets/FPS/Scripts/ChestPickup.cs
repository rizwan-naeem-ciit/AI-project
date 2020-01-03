using UnityEngine;

public class ChestPickup: MonoBehaviour
{
    [Header("Parameters")]
    [Tooltip("Amount of health to heal on pickup")]
    public bool key = false;

    Pickup m_Pickup;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {

        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth && player.key)
        {


            m_Pickup.PlayPickupFeedback();

            Destroy(gameObject);
        }
    }
}

