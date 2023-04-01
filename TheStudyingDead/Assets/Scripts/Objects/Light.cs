using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light : MonoBehaviour
{

    private Light2D _light;

    private void Start()
    {
        _light = GetComponent<Light2D>();
    }

    public void ChangeColorRed()
    {
        var color = new Color(1f, 0.5f, 0.5f);
        StartCoroutine(ChangeEngineColour(color));
    }

    public IEnumerator Flashing()
    {
        for (int i = 0; i < 10; i++)
        {
            _light.intensity = Random.Range(0.1f, 1.2f);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f)); 
        }
    }

  
    private IEnumerator ChangeEngineColour(Color color)
    {
        float tick = 0f;
        while (_light.color != color)
        {
            tick += Time.deltaTime * 2;
            _light.color = Color.Lerp(_light.color, color, tick);
            yield return null;
        }
    }
}
