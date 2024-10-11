using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 5;
    public Vector2 offset;

    public float limitMinX, limitMaxX, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;

    public Tilemap tilemap;
    private void Start()
    {
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;

        if (tilemap != null)
        {
            SetCameraLimitsFromTilemap();
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(
            Mathf.Clamp(target.position.x + offset.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth),   // X
            Mathf.Clamp(target.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight), // Y
            -10);                                                                                                  // Z
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothSpeed);
    }

    private void SetCameraLimitsFromTilemap()
    {
        // Get the bounds of the tilemap in cell coordinates
        BoundsInt bounds = tilemap.cellBounds;
        Debug.Log("bounds : " + bounds);

        // Convert the bounds to world coordinates
        Vector3 min = tilemap.CellToWorld(bounds.min);
        Vector3 max = tilemap.CellToWorld(bounds.max);

        // Set the camera limits
        limitMinX = min.x;
        limitMaxX = max.x;
        limitMinY = min.y;
        limitMaxY = max.y;
    }
}