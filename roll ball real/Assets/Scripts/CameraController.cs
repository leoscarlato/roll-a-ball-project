using UnityEngine;

// CÓDIGO CONSTRUÍDO COM AUXÍLIO DO CHATGPT

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public float rotationSpeed = 5.0f;

    public bool dynamicOffset = true;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if (dynamicOffset)
        {
            transform.position = player.transform.position + offset;
        }
        else
        {
            transform.position = player.transform.position + Quaternion.Euler(0, player.transform.eulerAngles.y, 0) * offset;
        }

        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
