using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Referência ao GameObject do jogador.
    public GameObject player;

    // A distância entre a câmera e o jogador.
    private Vector3 offset;

    // Velocidade de rotação da câmera.
    public float rotationSpeed = 5.0f;

    // Use esta flag se quiser que a câmera olhe diretamente para as costas do jogador.
    // Se false, a câmera manterá seu offset original mas ainda rotacionará com o jogador.
    public bool dynamicOffset = true;

    void Start()
    {
        // Calcular o offset inicial entre a posição da câmera e a posição do jogador.
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        // Manter o mesmo offset entre a câmera e o jogador ao longo do jogo.
        if (dynamicOffset)
        {
            // A câmera segue a posição do jogador mais o offset.
            transform.position = player.transform.position + offset;
        }
        else
        {
            // A câmera mantém a distância mas rotaciona em torno do jogador.
            transform.position = player.transform.position + Quaternion.Euler(0, player.transform.eulerAngles.y, 0) * offset;
        }

        // Alinha a rotação da câmera com a direção do movimento do jogador.
        // Calcula a rotação desejada da câmera com base na orientação do jogador.
        Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);

        // Interpola suavemente para a rotação desejada.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
