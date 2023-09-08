using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject deathEffect;

	public float health = 4f;

	public static int EnemiesAlive = 0;
	

	void Start ()
	{
		EnemiesAlive++;
	}

	void OnCollisionEnter2D (Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health)
		{
			Die();
		}
	}

	void Die ()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);

		EnemiesAlive--;
		if (EnemiesAlive <= 0)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

		Destroy(gameObject);
	}

}

