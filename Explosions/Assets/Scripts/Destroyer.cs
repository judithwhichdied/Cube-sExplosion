using System;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public event Action IsDestroyed;

    private void OnMouseUpAsButton()
    {
        Destroy(gameObject);

        IsDestroyed?.Invoke();
    }
}
