using UnityEngine;
using UnityEngine.SceneManagement;
/*
  Duda:
 *      ¿Para que se coloco esta libreria profe?
*/
public class LevelManager : MonoState<LevelManager>
{
    int sceneCount;

    protected override void Awake()
    {
        base.Awake();
        /*Se coloco aqui ya que el metodo Awake -
         es como un constructor que ejecutara los -
        comandos o instrucciones al iniciar el video -
        juego.*/

        /*Lo que hace esta linea de comando es tener el total -
         * de las escenas, esto porque recordemos que las escenas -
         * van de 0 a n - 1, por lo que tener el total de una vez -
         * facilita el proceso de validación entre si esta en la -
         * ultima escena, o esta en la principal entre otros más.
         */
        sceneCount = SceneManager.sceneCountInBuildSettings  - 1;   
    }
    /*
     
    Este es el que se va a encargar de las transiciones entre -
    escenas del videojuego.
     
    */

    public void FirstScene()
    {
        /*
         Si esta en la misma escena, entonces no haga nada -
         y salgase.
        
         Duda:
                ¿Para que sirve el GetActiveScene()?
         
         Respuesta:
                    Devuelve la escena actual.
         */
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }

        /*Esto es para que lea la escena #0, -
         el cual es la primera escena.*/
        SceneManager.LoadScene(0);
    }

    public void LastScene()
    {
        /*
        Si la escena actual es igual a la ultima escena -
        entonces salgase.
         */
        if (SceneManager.GetActiveScene().buildIndex == sceneCount)
        {
            return;
        }

        /*
         * Pero si no es la ultima escena entonces -
         * lea la ultima escena. */
        SceneManager.LoadScene(sceneCount);
    }

    public void NextScene()
    {
        /*
         Lo que hace esta linea de comando es tener la escena actual -
         del videojuego.
        */
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        
        /*
         Si la escena actual es mayor o igual a la cantidad de escenas -
         entonces no haga nada.
         
         Nota:
                Nunca deberia ser mayor, pero por aquello se coloca -
                si es igual.
         */
        if (currentScene >= sceneCount)
        {
            return;
        }

        /*
         Pero si es menor a la cantidad de escenas, esto quiere decir -
         que se puede avanzar a la siguiente escena.
        */
        SceneManager.LoadScene(currentScene + 1);
    }

    public void PreviousScene()
    {
        /*
         Lo que hace esta linea de comando es tener la escena actual -
         del videojuego.
        */
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        /*
         Si la escena actual es menor o igual a cero, entonces -
         se sale.
         */
        if (currentScene <= 0)
        {
            return;
        }

        /*
         Pero si no es menor o igual a cero, quiere decir que la escena previa -
         es igual a la escena actual - 1.
        */
        SceneManager.LoadScene(currentScene - 1);
    }
}
