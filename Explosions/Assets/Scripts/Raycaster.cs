using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Destroyer _destroyer;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity) == false)
                return;

            if (hit.collider.TryGetComponent(out Cube cube) == false)
                return;

            _destroyer.DestroyObject(cube);
        }
    }
}