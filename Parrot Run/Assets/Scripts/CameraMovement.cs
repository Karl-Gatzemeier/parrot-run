
using UnityEngine;

public class CameraMovement : MonoBehaviour

{
    public GameObject player;
    public int offset = 5;

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
    }
}
