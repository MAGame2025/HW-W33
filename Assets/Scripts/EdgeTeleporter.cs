using UnityEngine;

public class EdgeTeleporter : MonoBehaviour
{
    [SerializeField] private Transform targetEdge;   // where to appear
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;

        // Take player's position, replace only X with the target edge X
        Vector3 pos = other.transform.position;
        pos.x = targetEdge.position.x;
        other.transform.position = pos;
    }
}
