using UnityEngine;

public class EdgeTeleporter : MonoBehaviour
{
    [SerializeField] private Transform targetEdge;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;
        Vector3 pos = other.transform.position;
        pos.x = targetEdge.position.x;
        other.transform.position = pos;
    }
}
