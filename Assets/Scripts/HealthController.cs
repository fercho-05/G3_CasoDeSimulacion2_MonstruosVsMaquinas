using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float health;

    [SerializeField]
    float maxHealth = 100.0F;

    [SerializeField]
    float loseControlTimeout = 1.25F;

    [SerializeField]
    Vector2 reboundVelocity;

    Character2DController _characterController;
    HealthBarController _healthBarController;
    

    Rigidbody2D _rb;

    void Start()
    {
        health = maxHealth;

        _healthBarController = GetComponent<HealthBarController>(); //se carga HealthBar
        _healthBarController.Initialize(health);//inicializamos la barra de salud

        //_characterController = GetComponent<Character2DController>(); -
        //así funciona pero como la clase <Character2DController> -
        //ya es de tipo MonoState de la siguiente forma. 
        _characterController = Character2DController.Instance;
        _rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator LoseControl()
    {
        _characterController._canMove = false;
        yield return new WaitForSeconds(loseControlTimeout);
        _characterController._canMove = true;
    }

    void Rebound(Vector2 contactPoint)
    {
        _rb.velocity = new Vector2
            (-reboundVelocity.x *  contactPoint.x, reboundVelocity.y);
    }

    public void TakeDamage(float damage, Vector2 contactPoint)
    {
        health -= damage;
        if (health <= 0.0F)
        {
            Destroy(gameObject);
            GameOver();
            return;
        }

        _characterController.animator.SetTrigger("hit");
        _healthBarController.OnDamage.Invoke(damage);


        Rebound(contactPoint);
        StartCoroutine(LoseControl());
    }

    public void Heal(float value)
    {
        health += Mathf.Abs(value);
        _healthBarController.OnHeal.Invoke(value);
    }

    /*Método en el cual se llama la escena: Game over.*/
	public void GameOver()
	{
		SceneManager.LoadScene("Game over");
	}

}
