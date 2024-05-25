using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private GameObject _prefab;

    private Destroyer _destroyer;

    private int _minChanceValue = 0;
    private int _maxChanceValue = 1;

    private void Awake()
    {
        _destroyer = GetComponent<Destroyer>();
    }

    private void OnEnable()
    {
        _destroyer.IsDestroyed += Spawn;
        _destroyer.IsDestroyed += DecreaseSpawnChance;
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

        int randomValue;

        int spawnChance = Random.Range(_minChanceValue, _maxChanceValue);

        if (spawnChance == _minChanceValue)
        {
            randomValue = Random.Range(randomMinValue, randomMaxValue);

            for (int i = 0; i < randomValue; i++)
            {
                Create();
            }
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

        cube.GetComponent<Renderer>().material = _materials[Random.Range(randomMinValue, randomMaxValue)];
    }
}