using UnityEngine;

/// <summary>
/// Class to create a vector 3 randomly
/// </summary>

public class RandomVector3
{
    public Vector3 GiveMeARandomVector3(int minInclusiveX, int maxInclusiveX, int minInclusiveZ, int maxInclusiveZ)
    {
        return new Vector3(Random.Range(minInclusiveX, maxInclusiveX), 1, Random.Range(minInclusiveZ, maxInclusiveZ));
    }
}