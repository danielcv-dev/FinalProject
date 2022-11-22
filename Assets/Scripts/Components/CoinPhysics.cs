using UnityEngine;

/// <summary>
/// When i create the coin (money), add a force and torque so that look it similar to an explotion
/// </summary>
public class CoinPhysics : MonoBehaviour
{
    /// <summary>
    /// get the rigid body component, create a random vector 3 value and give it to the torque. 
    /// finally start a coroutineto remove the coin if the player don't take the money
    /// </summary>
    void Start()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * Random.Range(1.0f,5.0f), ForceMode.Impulse);
        RandomVector3 randomVector3 = new RandomVector3();
        rb.AddTorque(randomVector3.GiveMeARandomVector3(10, 150, 10, 150) * Random.Range(10.0f, 15.0f));
        StartCoroutine(GetComponent<TimerToRemove>().CoinTimer(3));
    }
}
