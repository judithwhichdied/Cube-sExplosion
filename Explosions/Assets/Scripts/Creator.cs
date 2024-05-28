using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Destroyer))]
[RequireComponent (typeof(Renderer))]
public class Creator : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private GameObject _prefab;

    private Destroyer _destroyer;

    private int _minChanceValue = 0;
    private int _maxChanceValue = 1;

    public event Action NotCreated;

    private void Awake()
    {
        _destroyer = GetComponent<Destroyer>();
    }

    private void OnEnable()
    {
        _destroyer.Destroyed += Spawn;
        _destroyer.Destroyed += DecreaseSpawnChance;
    }

    private void DecreaseSpawnChance()
    {
        int decreasingValue = 2;

        _maxChanceValue *= decreasingValue;
    }

    private void Spawn()
    {
        int randomMinValue = 2;

        int randomMaxValue = 7;

        int cubesCount;

        if (Utils.GetRandomNumber(_minChanceValue, _maxChanceValue) == _minChanceValue)
        {
            Debug.Log(2);

            cubesCount = Utils.GetRandomNumber(randomMinValue, randomMaxValue);

            for (int i = 0; i < cubesCount; i++)
            {
                Create();
            }
        }
        else
        {
            Debug.Log(1);
            NotCreated?.Invoke();
        }
    }

    private void Create()
    {
        int decreasingValue = 2;

        int randomMinValue = 0;
        int randomMaxValue = 9;

        GameObject cube;

        cube = Instantiate(_prefab);

        cube.transform.position = transform.position;
        cube.transform.localScale = transform.localScale / decreasingValue;

        cube.GetComponent<Renderer>().material = _materials[Utils.GetRandomNumber(randomMinValue, randomMaxValue)];
    }
}

public class Utils
{
    private static System.Random s_random = new System.Random();

    public static int GetRandomNumber(int min, int max)
    {
        return s_random.Next(min, max);
    }
}