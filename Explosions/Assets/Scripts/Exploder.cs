using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Creator))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private float _maxExplosionRadius;
    [SerializeField] private float _maxExplosionForce;

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

    private void Explode(Cube cube)
    {
        List<Rigidbody> cubes = GetExplodableObjects(cube);

        float explosionForce = _maxExplosionForce;

        foreach (Rigidbody explodableObject in cubes)
        {
            var heading = explodableObject.transform.position - cube.transform.position;

            var distance = heading.magnitude;

            explosionForce *= _proportionValue / cube.transform.localScale.x;

            explosionForce *= _proportionValue / distance;

            explodableObject.AddExplosionForce(explosionForce, cube.transform.position, _maxExplosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Cube cube)
    {
        float explosionRadius = _maxExplosionRadius;

        explosionRadius *= (_proportionValue / cube.transform.localScale.x);

        Collider[] hits = Physics.OverlapSphere(cube.transform.position, explosionRadius);

        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.gameObject == cube.gameObject)
                continue;

            if(hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}