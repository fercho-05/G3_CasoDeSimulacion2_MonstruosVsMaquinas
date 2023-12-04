using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	[SerializeField]
	float damage = 10.0F;

	public static int _Cantidad = 0;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))//si el colisionador con el que choque es igual a "player", significa que choco con el player
		{
			Vector2 contactPoint = other.GetContact(0).normal;

			if (contactPoint.y < -0.9F) /*Se corrigijio esta parte para que el enemigo no se autodestruya al tocar al jugador después de hacerle daño.*/
			{
				Character2DController.Instance.Rebound(); //rebote 
				Destroy(gameObject); //mata al enemigo

				/*Contador para poder obtener la cantidad
				 * de los enemigos bajados: */
				_Cantidad += 1;	
				
				/*Para verificar el contador en la consola-
				 * además de servir como una guía para el jugador -
				 * ya que le indica cuantos enemigos bajo: */
				Debug.Log(_Cantidad);

				/*Condición: si la variable _Cantidad es igual a 25 -
				 * (que serian los enemigos totales), entonces mande a -
				 * llamar al método: Victoria()*/
				if (_Cantidad == 25)
				{
					Victoria();
				}
			}
			else
			{
				HealthController controller = other.collider.GetComponent<HealthController>(); //entonces busque el health bar
				controller.TakeDamage(damage, contactPoint);				
			}

		}
	}


	/*Método en el cual se llama la escena de victoria.*/
	public void Victoria()
	{
		SceneManager.LoadScene("Victory");
	}
}
