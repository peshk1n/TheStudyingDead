using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Explore : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight;
    [SerializeField] List<GameObject> _activeObjects;
    [SerializeField] List<Collider2D> _activeCollider;
    [SerializeField] List<GameObject> _offObjects;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject obj in _offObjects)
            {
                if (obj != null) obj?.SetActive(false);
            }
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
