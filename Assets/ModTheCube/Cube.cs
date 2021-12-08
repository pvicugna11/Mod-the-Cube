using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    private Material material;
    private float r; // red
    private float g; // green
    private float b; // blue
    private float a; // alpha

    private float rotationSpeed = 30.0f;
    private float scale;
    private float minScale = 1.0f;
    private float maxScale = 5.0f;

    private float startTime = 1.0f;
    private float invokeInterval = 1.0f;
    
    void Start()
    {
        material = Renderer.material;
        transform.position = Vector3.zero;

        StartCoroutine("Change");
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, -rotationSpeed * Time.deltaTime, 0.0f);
    }

    private IEnumerator Change()
    {
        while(true)
        {
            invokeInterval = Random.Range(1.0f, 3.0f);

            ChangeScale();
            ChangeColor();

            yield return new WaitForSeconds(invokeInterval);
        }
    }

    private void ChangeScale()
    {
        scale = Random.Range(minScale, maxScale);
        transform.localScale = Vector3.one * scale;
    }

    private void ChangeColor()
    {
        r = Random.Range(0.0f, 1.0f);
        g = Random.Range(0.0f, 1.0f);
        b = Random.Range(0.0f, 1.0f);
        a = Random.Range(0.0f, 1.0f);

        material.color = new Color(r, g, b, a);
    }
}
