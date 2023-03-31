using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Explore : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight;
    [SerializeField] List<GameObject> _activeObjects;
    [SerializeField] List<Collider2D> _activeCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            _globalLight.intensity = 0.03f;
            foreach (GameObject @object in _activeObjects)
            {
                @object.SetActive(true);
            }
            foreach(Collider2D collider in _activeCollider)
                collider.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
