using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create a sound an particle effect
/// </summary>
public class LlamaFX : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField]
    AudioSource audioSource;
    [Tooltip("Drag the sound for after the llama was catched")]
    [SerializeField]
    AudioClip audioClip;
    [Header("Particle")]
    [Tooltip("Drag the particle for after the llama was catched")]
    [SerializeField]
    ParticleSystem particle;

    private void Start()
    {
        PlayFX();
    }

    public void PlayFX()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        float duration = particle.main.duration / 2;
        particle.Play();
        Destroy(this.gameObject, duration);
    }

}
