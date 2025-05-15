using UnityEngine;

public class Shooter : MonoBehaviour
{
    public AudioSource shootSound;
    public GameObject bulletHolePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootSound.Play();

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out hit))
            {
                GameObject bulletHole = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(hit.normal));
                Destroy(bulletHole, 10f); // Delete after 10 sec
            }
        }
    }
}

