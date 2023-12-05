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
        // Küpü bul
        cube = GameObject.Find("Cube");

        // Sað ve Sol butonlara týklanma olaylarýna fonksiyonlarý baðla
        rightButton = transform.Find("rightButton").GetComponent<Button>();
        rightButton.onClick.AddListener(MoveCubeRight);

        leftButton = transform.Find("leftButton").GetComponent<Button>();
        leftButton.onClick.AddListener(MoveCubeLeft);
    }

    public void MoveCubeRight()
    {
        // Saða hareket et
        cube.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    public void MoveCubeLeft()
    {
        // Sola hareket et
        cube.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
}