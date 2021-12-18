using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private Renderer paralax;

    void Update()
    {
        Vector2 offset = Vector2.right * speed * Time.deltaTime;
        paralax.material.mainTextureOffset += offset;
    }
}