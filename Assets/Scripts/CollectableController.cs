using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [SerializeField]
    public CollectableTypes collectableType;

    [SerializeField]
    public bool isHealht = false;

    [SerializeField]
    public float value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryController.Instance.Add(collectableType, value, isHealht);
            Destroy(gameObject);
        }
    }

}
