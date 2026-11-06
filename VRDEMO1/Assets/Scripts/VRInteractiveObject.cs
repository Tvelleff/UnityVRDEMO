using UnityEngine;

public class VRInteractiveObject : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    public void OnSelected()
    {
        objectRenderer.material.color = Random.ColorHSV();

        Debug.Log(gameObject.name + " was selected!");
    }

    public void OnGazeEnter()
    {
        transform.localScale = Vector3.one * 1.2f;
    }

    public void OnGazeExit()
    {
        transform.localScale = Vector3.one;
    }
}