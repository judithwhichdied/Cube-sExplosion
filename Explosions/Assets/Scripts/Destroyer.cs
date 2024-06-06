using System;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public event Action<Cube> Destroyed;

    public void DestroyObject(Cube cube)
    {
            Destroyed?.Invoke(cube);
            Destroy(cube.gameObject);
    }
}