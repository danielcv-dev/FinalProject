using UnityEngine;


/// <summary>
/// Play the sound and particle effects in the player
/// </summary>
public class PlayerFX : MonoBehaviour
{
    AudioSource audioSourceWalk;
    [Header("FX")]
    [Tooltip("Drag the sound of steps")]
    [SerializeField]
    AudioClip soundWalk;
    [Tooltip("Drag the particles of the step")]
    [SerializeField]
    ParticleSystem stepDustParticle;
    
    /// <summary>
    /// Add an audio source component and asign a clip 
    /// </summary>
    void Start()
    {
        audioSourceWalk = gameObject.AddComponent<AudioSource>();
        audioSourceWalk.clip = soundWalk;
    }

    /// <summary>
    /// in every step play one shot of the step sound and play the particle dust
    /// </summary>

    public void FootstepEvent()
    {
        audioSourceWalk.PlayOneShot(soundWalk);
        stepDustParticle.Play();
    }

}
