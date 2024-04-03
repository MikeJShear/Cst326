using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
	public float health;
    private bool isDead = false;
    public GameObject deathEffect;
    public int worth = 300;

    void Start()
    {
        health = 10;
        speed = startSpeed;
    }

    public void Slow( float prct)
    {
        speed = startSpeed * (1f-prct);
    }
    public void TakeDamage (float amount)
	{
		health -= amount;
		if (health <= 0 && !isDead)
		{
            PlayerStats.Money += worth;
			Die();
		}
	}

    void Die ()
	{
		isDead = true;

		

        Debug.Log("Enemy died, money increased to: " + PlayerStats.Money); // Add this line

		GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(effect, 5f);

		Destroy(gameObject);
	}

}
