using UnityEngine;

public enum Alliance { neutral, hostile, friendly }

public class DamageDealer : MonoBehaviour
{
    // Configuration
    [SerializeField] [Range(50f, 500f)] float damage = 100f;
    [SerializeField] Alliance alliance = Alliance.neutral;
    [SerializeField] bool destroyOnHit = false;


    public float GetDamage()
    {
        return damage;
    }

    public Alliance GetAlliance()
    {
        return alliance;
    }

    public void Hit()
    {
        //TODO: should only apply to projectiles
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }


}
