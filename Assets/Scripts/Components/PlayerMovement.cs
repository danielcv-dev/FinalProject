using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    /// <summary>
    /// Get the velocity of the agent
    /// </summary>
    /// <returns>vector 3 velocity</returns>
    public Vector3 GetAgentVelocity()
    {
        return agent.velocity;
    }

    /// <summary>
    /// set the destination to the agent
    /// </summary>
    /// <param name="_hitPoint">the place that we click in the floor</param>
    public void MoveAgent(Vector3 _hitPoint)
    {
        agent.SetDestination(_hitPoint);
    }
}
