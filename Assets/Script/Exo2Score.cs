using UnityEngine;

public class Exo2Score : MonoBehaviour
{
    public int points = 100;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            FindAnyObjectByType<Exo2>().AddPoints(points);
            Destroy(other);

        }
    }
}
