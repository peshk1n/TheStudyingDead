using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lantern : MonoBehaviour
{
    [SerializeField] private Light2D _light;
    [SerializeField] private bool _isEnabled = false;
    [SerializeField] private int _charge = 3;

    public bool IsEnabled => _isEnabled;

    public void TurnOn()
    {
        if (_charge <= 0)
            return;

        _light.intensity = 1;
        _isEnabled = true;
    }

    public void TurnOff()
    {
        _light.intensity = 0;
        _isEnabled = false;
    }

}
