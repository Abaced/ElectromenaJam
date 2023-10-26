using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _healthJ1ParticleSystem;
    [SerializeField] private ParticleSystem _healthJ2ParticleSystem;


    public void OnHitVFX(int player)
    {
        if (player == 1)
        {
            _healthJ1ParticleSystem.Play();
        }
        else if(player == 2)
        {
            _healthJ2ParticleSystem.Play();
        }
    }
}
