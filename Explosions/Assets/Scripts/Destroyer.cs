using System;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public event Action Destroyed;

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);

        Destroyed?.Invoke();
    }
}
