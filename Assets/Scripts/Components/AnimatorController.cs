using UnityEngine;

/// <summary>
/// Control the character animation
/// </summary>
public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    PlayerMovement player;


    /// <summary>
    /// In the start get all the references that i need.
    /// </summary>
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponentInParent<PlayerMovement>();
    }

    /// <summary>
    /// in the fixed update call the PlayerIsInMovement
    /// </summary>
    private void FixedUpdate()
    {
        PlayerIsInMovement();
    }

    /// <summary>
    /// send to the animator the velocities X and Z absolute and in the blend three 
    /// run the animation when the player is in movement
    /// </summary>
    void PlayerIsInMovement()
    {
        animator.SetFloat("VelocityX", Mathf.Abs(player.GetAgentVelocity().x));
        animator.SetFloat("VelocityZ", Mathf.Abs(player.GetAgentVelocity().z));
    }


}
