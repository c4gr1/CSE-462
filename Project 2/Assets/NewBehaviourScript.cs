using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;
using static MatrixExtensions;

public class ShowPointsFromFile : MonoBehaviour
{
    public Button rigidTransformationButton;
    public Button rigidTransformationScaleButton;
    public Button showOriginalButton;
    public Button showTransformedButton;
    public Button showOriginalButton2;
    public Button showTransformedButton2;
    public Button startButton;

    public Text transformationMatrixText;

    public List<Vector3> pointSet;
    public List<Vector3> pointSet2;
    public List<Vector3> tempPointSet2;

    public Matrix4x4 transformationMatrix;

    private bool listenersAdded = false;

    public bool applyGlobalScale = false;
    void Start()
    {
        rigidTransformationButton = GameObject.Find("Button").GetComponent<UnityEngine.UI.Button>();
        rigidTransformationScaleButton = GameObject.Find("Button2").GetComponent<UnityEngine.UI.Button>();
        showOriginalButton = GameObject.Find("Button3").GetComponent<Button>();
        showTransformedButton = GameObject.Find("Button4").GetComponent<Button>();
        showOriginalButton2 = GameObject.Find("Button5").GetComponent<Button>();
        showTransformedButton2 = GameObject.Find("Button6").GetComponent<Button>();

        showOriginalButton.gameObject.SetActive(false);
        showTransformedButton.gameObject.SetActive(false);
        showOriginalButton2.gameObject.SetActive(false);
        showTransformedButton2.gameObject.SetActive(false);
        rigidTransformationButton.gameObject.SetActive(false);
        rigidTransformationScaleButton.gameObject.SetActive(false);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !listenersAdded)
        {
            // Butonlara týklama olay dinleyicilerini ekleme
            startButton.onClick.AddListener(StartButtonClick);
            rigidTransformationButton.onClick.AddListener(OnRigidButtonClick);
            rigidTransformationScaleButton.onClick.AddListener(OnRigidUpToScaleButtonClick);
            showOriginalButton.onClick.AddListener(OnOriginalButtonClick);
            showTransformedButton.onClick.AddListener(OnTransformedButtonClick);
            showOriginalButton2.onClick.AddListener(OnOriginalButtonClick2);
            showTransformedButton2.onClick.AddListener(OnTransformedButtonClick2);

            listenersAdded = true; // Dinleyicilerin bir daha eklenmemesi için kontrol
        }
    }

        void StartButtonClick()
    {

        // Ýlgili butonlarý devre dýþý býrak ve yeni butonlarý etkinleþtir
        startButton.gameObject.SetActive(false);
        rigidTransformationButton.gameObject.SetActive(true);
        rigidTransformationScaleButton.gameObject.SetActive(true);

    }
    void OnRigidButtonClick()
    {

        // Ýlgili butonlarý devre dýþý býrak ve yeni butonlarý etkinleþtir
        rigidTransformationButton.gameObject.SetActive(false);
        rigidTransformationScaleButton.gameObject.SetActive(false);
        showOriginalButton.gameObject.SetActive(true);
        showTransformedButton.gameObject.SetActive(true);
        showOriginalButton2.gameObject.SetActive(false);
        showTransformedButton2.gameObject.SetActive(false);

    }

    void OnRigidUpToScaleButtonClick()
    {
        //showPointsButton.onClick.AddListener(ShowPoints);

        // Ýlgili butonlarý devre dýþý býrak ve yeni butonlarý etkinleþtir
        rigidTransformationButton.gameObject.SetActive(false);
        rigidTransformationScaleButton.gameObject.SetActive(false);
        showOriginalButton.gameObject.SetActive(false);
        showTransformedButton.gameObject.SetActive(false);
        showOriginalButton2.gameObject.SetActive(true);
        showTransformedButton2.gameObject.SetActive(true);

    }

    public void OnOriginalButtonClick()
    {
        Debug.Log("originalllllll");
        ShowPoints();
        showOriginalButton.gameObject.SetActive(false);
        showTransformedButton.gameObject.SetActive(false);
    }

    public void OnTransformedButtonClick()
    {
        Debug.Log("transformeddddddd");
        ShowPoints();
        ShowMovementLine();
        showOriginalButton.gameObject.SetActive(false);
        showTransformedButton.gameObject.SetActive(false);
    }

    public void OnOriginalButtonClick2()
    {
        Debug.Log("originalllllll2222");
        ShowPoints2();
        showOriginalButton2.gameObject.SetActive(false);
        showTransformedButton2.gameObject.SetActive(false);
    }

    public void OnTransformedButtonClick2()
    {
        Debug.Log("transformeddddddd2222");
        ShowPoints2();
        ShowMovementLine();
        showOriginalButton2.gameObject.SetActive(false);
        showTransformedButton2.gameObject.SetActive(false);
    }

    void LoadPointCloud(string filePath, List<Vector3> set)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            set.Clear();
            int numPoints = int.Parse(reader.ReadLine());

            Debug.Log(numPoints);

            for (int i = 0; i < numPoints; i++)
            {
                string[] coordinates = reader.ReadLine().Split(' ');
                float x = float.Parse(coordinates[0]);
                float y = float.Parse(coordinates[1]);
                float z = float.Parse(coordinates[2]);
                set.Add(new Vector3(x, y, z));
            }
        }
    }

     void ShowPoints()
    {
        // Dosyanýn tam yolu, eðer dosya Assets klasöründe deðilse, uygun þekilde güncellenmelidir.
        string fullPath = Application.dataPath + "/path_to_file_P.txt";

        // Noktalarý yükleyin
        LoadPointCloud(fullPath, pointSet);

        string fullPath2 = Application.dataPath + "/path_to_file_Q.txt";

        LoadPointCloud(fullPath2, pointSet2);


        Debug.Log("Point Set P:" + pointSet.Count);
        foreach (Vector3 point in pointSet)
        {
            Debug.Log(point.x + " " + point.y + " " + point.z);
        }

        Debug.Log("Point Set Q:" + pointSet2.Count);
        foreach (Vector3 point in pointSet2)
        {
            Debug.Log(point.x + " " + point.y + " " + point.z);
        }

        for (int i = 0; i < pointSet2.Count; i++)
        {
            tempPointSet2.Add(pointSet2[i]);
        }
    
        // Rigid transformation hesapla ve uygula
        CalculateRigidTransformation(pointSet, pointSet2);

        Debug.Log("After rigid:");

        // Noktalarý ekranda gösterin
        DisplayPoints(pointSet, Color.blue);
        DisplayPoints(tempPointSet2, Color.green);
        DisplayPoints(pointSet2, Color.red);
  
    }

    void ShowPoints2()
    {
        // Dosyanýn tam yolu, eðer dosya Assets klasöründe deðilse, uygun þekilde güncellenmelidir.
        string fullPath = Application.dataPath + "/path_to_file_P.txt";

        // Noktalarý yükleyin
        LoadPointCloud(fullPath, pointSet);

        string fullPath2 = Application.dataPath + "/path_to_file_Q.txt";

        LoadPointCloud(fullPath2, pointSet2);


        Debug.Log("Point Set P:" + pointSet.Count);
        foreach (Vector3 point in pointSet)
        {
            Debug.Log(point.x + " " + point.y + " " + point.z);
        }

        Debug.Log("Point Set Q:" + pointSet2.Count);
        foreach (Vector3 point in pointSet2)
        {
            Debug.Log(point.x + " " + point.y + " " + point.z);
        }

        for (int i = 0; i < pointSet2.Count; i++)
        {
            tempPointSet2.Add(pointSet2[i]);
        }

        applyGlobalScale = true;

        // Rigid transformation hesapla ve uygula
        CalculateRigidTransformation(pointSet, pointSet2);

        Debug.Log("After rigid:");

        // Noktalarý ekranda gösterin
        DisplayPoints(pointSet, Color.blue);
        DisplayPoints(tempPointSet2, Color.green);
        DisplayPoints(pointSet2, Color.red);

    }

    void DisplayPoints(List<Vector3> points, Color color)
    {
        foreach (Vector3 point in points)
        {
            GameObject pointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pointObject.transform.position = point;
            pointObject.GetComponent<Renderer>().material.color = color;

            pointObject.transform.localScale = new Vector3(5f,5f,5f);
        }
    }

    void ShowMovementLine()
    {
        // Çizgiyi oluþtur
        for (int i = 0; i < pointSet.Count; i++)
        {
            GameObject lineObject = new GameObject("Line");
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderer.positionCount = 2;

            // 1. setin i. elemanýndan
            lineRenderer.SetPosition(0, pointSet[i]);

            // 2. setin i. elemanýna kadar çizgi çiz
            lineRenderer.SetPosition(1,pointSet2[i]);
        }
    }



    void CalculateRigidTransformation(List<Vector3> set1, List<Vector3> set2)
    {
        // Calculate the centroids of the two point sets
        Vector3 centroid1 = CalculateCentroid(set1);
        Vector3 centroid2 = CalculateCentroid(set2);

        // Center the point sets around their respective centroids
        CenterPoints(set1, centroid1);
        CenterPoints(set2, centroid2);

        // Calculate the covariance matrix between the two point sets
        Matrix4x4 covarianceMatrix = CalculateCovarianceMatrix(set1, set2);

        // Perform singular value decomposition (SVD) on the covariance matrix
        Matrix4x4 rotationMatrix = CalculateRotationMatrix(covarianceMatrix);
        Vector3 translationVector = centroid2 - rotationMatrix.MultiplyPoint(centroid1);

        // Construct the rigid transformation matrix
        Matrix4x4 transformationMatrix = Matrix4x4.identity;
        transformationMatrix.SetRow(0, new Vector4(rotationMatrix.GetRow(0).x, rotationMatrix.GetRow(0).y, rotationMatrix.GetRow(0).z, translationVector.x));
        transformationMatrix.SetRow(1, new Vector4(rotationMatrix.GetRow(1).x, rotationMatrix.GetRow(1).y, rotationMatrix.GetRow(1).z, translationVector.y));
        transformationMatrix.SetRow(2, new Vector4(rotationMatrix.GetRow(2).x, rotationMatrix.GetRow(2).y, rotationMatrix.GetRow(2).z, translationVector.z));

        if (applyGlobalScale)
        {
            // Calculate the global scale factor
            float scaleX = Mathf.Sqrt(covarianceMatrix[0, 0]);
            float scaleY = Mathf.Sqrt(covarianceMatrix[1, 1]);
            float scaleZ = Mathf.Sqrt(covarianceMatrix[2, 2]);

            // Apply the rigid transformation up to a global scale
            Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(scaleX, scaleY, scaleZ));
            transformationMatrix = scaleMatrix * Matrix4x4.TRS(Vector3.zero, rotationMatrix.rotation, Vector3.one) * Matrix4x4.Translate(translationVector);
        }
        else
        {
            // Apply the standard rigid transformation
            transformationMatrix = Matrix4x4.TRS(Vector3.zero, rotationMatrix.rotation, Vector3.one) * Matrix4x4.Translate(translationVector);
        }

        transformationMatrixText.text = $"Transformation Matrix: \n{transformationMatrix.ToString("F3")}";

        ApplyTransformation(set2, transformationMatrix);
    }

    Vector3 CalculateCentroid(List<Vector3> points)
    {
        Vector3 centroid = Vector3.zero;
        foreach (Vector3 point in points)
        {
            centroid += point;
        }
        return centroid / points.Count;
    }

    void CenterPoints(List<Vector3> points, Vector3 centroid)
    {
        for (int i = 0; i < points.Count; i++)
        {
            points[i] -= centroid;
        }
    }

    Matrix4x4 CalculateCovarianceMatrix(List<Vector3> set1, List<Vector3> set2)
    {
        // Initialize a 3x3 matrix for covariance calculation
        Matrix4x4 covarianceMatrix = new Matrix4x4();

        // Calculate the mean of each set
        Vector3 meanSet1 = CalculateMean(set1);
        Vector3 meanSet2 = CalculateMean(set2);

        // Calculate covariance matrix
        for (int i = 0; i < set1.Count; i++)
        {
            Vector3 deviation1 = set1[i] - meanSet1;
            Vector3 deviation2 = set2[i] - meanSet2;

            covarianceMatrix[0, 0] += deviation1.x * deviation2.x;
            covarianceMatrix[0, 1] += deviation1.x * deviation2.y;
            covarianceMatrix[0, 2] += deviation1.x * deviation2.z;

            covarianceMatrix[1, 0] += deviation1.y * deviation2.x;
            covarianceMatrix[1, 1] += deviation1.y * deviation2.y;
            covarianceMatrix[1, 2] += deviation1.y * deviation2.z;

            covarianceMatrix[2, 0] += deviation1.z * deviation2.x;
            covarianceMatrix[2, 1] += deviation1.z * deviation2.y;
            covarianceMatrix[2, 2] += deviation1.z * deviation2.z;
        }

        // Normalize by the number of points
        float normalizationFactor = 1.0f / set1.Count;
        covarianceMatrix[0, 0] *= normalizationFactor;
        covarianceMatrix[0, 1] *= normalizationFactor;
        covarianceMatrix[0, 2] *= normalizationFactor;

        covarianceMatrix[1, 0] *= normalizationFactor;
        covarianceMatrix[1, 1] *= normalizationFactor;
        covarianceMatrix[1, 2] *= normalizationFactor;

        covarianceMatrix[2, 0] *= normalizationFactor;
        covarianceMatrix[2, 1] *= normalizationFactor;
        covarianceMatrix[2, 2] *= normalizationFactor;

        return covarianceMatrix;
    }


    Vector3 CalculateMean(List<Vector3> points)
    {
        Vector3 mean = Vector3.zero;
        foreach (Vector3 point in points)
        {
            mean += point;
        }
        return mean / points.Count;
    }


    Matrix4x4 CalculateRotationMatrix(Matrix4x4 covarianceMatrix)
    {
        // Use Unity's built-in Quaternion to Matrix conversion
        Quaternion rotationQuaternion = Quaternion.LookRotation(covarianceMatrix.GetColumn(2), covarianceMatrix.GetColumn(1));
        return Matrix4x4.Rotate(rotationQuaternion);
    }

    void ApplyTransformation(List<Vector3> points, Matrix4x4 transformationMatrix)
    {
        for (int i = 0; i < points.Count; i++)
        {
            points[i] = transformationMatrix.MultiplyPoint(points[i]);
        }
    }
}
