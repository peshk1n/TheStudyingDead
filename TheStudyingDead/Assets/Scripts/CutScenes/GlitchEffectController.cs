using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchEffectController : MonoBehaviour
{
    [SerializeField] Material _screenMaterial;
    [SerializeField] Player _player;

    public void SetParameters()
    {
        float hp = (float)_player.CurHealth / (float)_player.MaxHealth;

        if (hp >= 0.9)
        {
            DisableGlitchEffect();
            return;
        }

        _screenMaterial.SetFloat("_Switch", 1-hp);
        _screenMaterial.SetFloat("_NoiseAmount", 50);
        _screenMaterial.SetFloat("_VignetteRadius", Mathf.Lerp(0.5f, 0.8f, hp));
        _screenMaterial.SetFloat("_ScanLinesStrength", hp);

        if (hp <= 0.7)
        {
            _screenMaterial.SetFloat("_GlitchStrength", 1);
        }
    }

    public void EnableGlitchEffect()
    {
        _screenMaterial.SetFloat("_Switch", 0.2f);

        _screenMaterial.SetFloat("_NoiseAmount", 0);
        _screenMaterial.SetFloat("_GlitchStrength", 0);
        _screenMaterial.SetFloat("_ScanLinesStrength", 1);
        _screenMaterial.SetFloat("_VignetteRadius", 1);
        //_screenMaterial.SetFloat("_VignetteSoftness", 0.5f);
    }

    public void DisableGlitchEffect()
    {
        EnableGlitchEffect();
        _screenMaterial.SetFloat("_Switch", 0);
    }

    public void OnDisable()
    {
        DisableGlitchEffect();
    }

    public void ShowDeathScreenEffect()
    {
        _screenMaterial.SetFloat("_Switch", 1);

        _screenMaterial.SetFloat("_NoiseAmount", 30);
        _screenMaterial.SetFloat("_GlitchStrength", 1);
        _screenMaterial.SetFloat("_ScanLinesStrength", 0);
        _screenMaterial.SetFloat("_VignetteRadius", 1);
        //_screenMaterial.SetFloat("_VignetteSoftness", 0.5f);
    }
}
