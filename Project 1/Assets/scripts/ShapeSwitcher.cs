using UnityEngine;
using UnityEngine.UI;

public class ShapeSwitcher : MonoBehaviour
{
    private GameObject currentShape;

    public Button cubeButton;
    public Button cylinderButton;
    public Button sphereButton;

    void Start()
    {
        // Baþlangýçta sahnedeki küp bul
        currentShape = GameObject.Find("Cube");

        // Butonlara týklama olaylarýna fonksiyonlarý baðla
        cubeButton = GameObject.Find("CubeButton").GetComponent<Button>();
        cubeButton.onClick.AddListener(SwitchToCube);

        cylinderButton = GameObject.Find("CylinderButton").GetComponent<Button>();
        cylinderButton.onClick.AddListener(SwitchToCylinder);

        sphereButton = GameObject.Find("SphereButton").GetComponent<Button>();
        sphereButton.onClick.AddListener(SwitchToSphere);
    }

    public void SwitchToCube()
    {
        SwitchShape(PrimitiveType.Cube);
    }

    public void SwitchToCylinder()
    {
        SwitchShape(PrimitiveType.Cylinder);
    }

    public void SwitchToSphere()
    {
        SwitchShape(PrimitiveType.Sphere);
    }

    void SwitchShape(PrimitiveType shapeType)
    {

        currentShape = GameObject.CreatePrimitive(shapeType);

        // Oluþturulan yeni þeklin scale deðerini ayarla
        currentShape.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
