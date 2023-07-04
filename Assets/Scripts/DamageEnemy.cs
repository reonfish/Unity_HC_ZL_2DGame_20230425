using UnityEngine;

public class DamageEnemy : DamageBasic
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("武器"))
        {
            Damage(50);
            
        }
    }
}