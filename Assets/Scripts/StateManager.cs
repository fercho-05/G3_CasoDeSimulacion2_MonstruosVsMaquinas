using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    int _Cantidad = 0;

   /* protected override void Awake()
    {
        base.Awake();
    }*/

    public int getCantidad()
    {
        return _Cantidad;
    }

    public void setCantidad(int newCantidad)
    {
		_Cantidad = newCantidad;
    }
}
