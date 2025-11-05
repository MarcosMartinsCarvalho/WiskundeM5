using UnityEngine;

public class scrollingBackground : MonoBehaviour
{
    [SerializeField]
    private Renderer bgRenderer;
    public float speed = 2.0f;
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}