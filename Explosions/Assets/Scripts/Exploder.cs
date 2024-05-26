using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Creator))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private Creator _creator;

    private int _proportionValue = 1;

    private void Awake()
    {
        _creator = GetComponent<Creator>();
    }

    private void OnEnable()
    {
        _creator.NotCreated += Explode;
    }

    private void OnDisable()
    {
        _creator.NotCreated -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            _explosionForce *= (_proportionValue / transform.localScale.x);
            _explosionForce *= (_proportionValue / _explosionRadius);

            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        _explosionRadius *= (_proportionValue / transform.localScale.x);

        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}