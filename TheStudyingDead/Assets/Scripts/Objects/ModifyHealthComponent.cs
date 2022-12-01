using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyHealthComponent : MonoBehaviour
{
    [SerializeField] private int _healthDelta;

    public void Apply(GameObject target)
    {
        if (target.TryGetComponent<Player>(out Player player))
        {
            player.ModifyHealth(_healthDelta);
        }
    }
}
