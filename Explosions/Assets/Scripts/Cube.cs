using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;

    private MeshRenderer _renderer;

    public int MinCreateChance { get; private set; } = 0;
    public int MaxCreateChance { get; private set; } = 1;

    public void Initialize(Vector3 position, Vector3 scale, int maxCreateChance)
    {
        int decreasingValue = 2;
        int randomMinValue = 0;
        int randomMaxValue = 9;

        transform.position = position;
        transform.localScale = scale / decreasingValue;

        _renderer = GetComponent<MeshRenderer>();

        _renderer.material = _materials[Random.Range(randomMinValue, randomMaxValue)];

        MaxCreateChance = maxCreateChance;
    }
}
