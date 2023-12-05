using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 50f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Kameray� yatay eksende d�nd�rme
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Kameray� dikey eksende d�nd�rme (iste�e ba�l�)
        transform.Rotate(Vector3.right, verticalInput * rotationSpeed * Time.deltaTime);
    }
}

