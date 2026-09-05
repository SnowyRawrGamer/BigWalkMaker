using UnityEngine;

namespace BigWalkMaker.Builder;

public sealed class PlacementController : MonoBehaviour
{
    public float FlySpeed = 8f;
    public GameObject? SelectedPrefab { get; set; }

    private void Update()
    {
        if (Camera.main is null) return;
        var direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump") - Input.GetAxis("Crouch"), Input.GetAxis("Vertical"));
        Camera.main.transform.position += Camera.main.transform.TransformDirection(direction) * (FlySpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0)) PlaceAtRaycast();
    }

    private void PlaceAtRaycast()
    {
        if (SelectedPrefab is null || Camera.main is null) return;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, 500f)) Object.Instantiate(SelectedPrefab, hit.point, Quaternion.identity);
    }
}
