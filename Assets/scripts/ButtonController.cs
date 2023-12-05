using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private GameObject cube;
    public float movementSpeed = 5f;
    public Button rightButton;
    public Button leftButton;
    void Start()
    {
        // K�p� bul
        cube = GameObject.Find("Cube");

        // Sa� ve Sol butonlara t�klanma olaylar�na fonksiyonlar� ba�la
        rightButton = transform.Find("rightButton").GetComponent<Button>();
        rightButton.onClick.AddListener(MoveCubeRight);

        leftButton = transform.Find("leftButton").GetComponent<Button>();
        leftButton.onClick.AddListener(MoveCubeLeft);
    }

    public void MoveCubeRight()
    {
        // Sa�a hareket et
        cube.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    public void MoveCubeLeft()
    {
        // Sola hareket et
        cube.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
}