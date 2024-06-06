using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent (typeof(Destroyer))]
public class Creator : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    private Destroyer _destroyer;
  
    public event Action<Cube> NotCreated;

    private void Awake()
    {
        _destroyer = GetComponent<Destroyer>();
    }

    private void OnEnable()
    {
        _destroyer.Destroyed += Spawn;
    }

    private void OnDisable()
    {
        _destroyer.Destroyed -= Spawn;
    }

    private void Spawn(Cube cube)
    {       
        int randomMinValue = 2;

        int randomMaxValue = 7;

        int cubesCount;

        if (Random.Range(cube.MinCreateChance, cube.MaxCreateChance) == cube.MinCreateChance)
        {
            cubesCount = Random.Range(randomMinValue, randomMaxValue);

            for (int i = 0; i < cubesCount; i++)
            {
               Create(cube);
            }
        }
        else
        {
            NotCreated?.Invoke(cube);
        }
    }

    private void Create(Cube cube)
    {
        int decreasingValue = 2;

       Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
       newCube.Initialize(cube.transform.position, cube.transform.localScale, cube.MaxCreateChance * decreasingValue);
    }
}