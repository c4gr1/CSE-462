using UnityEngine;
public static class MatrixExtensions
{
    public static bool DecomposeSwingTwist(Matrix4x4 matrix, Vector3 swingAxis, out Vector3 scale, out Quaternion rotation, out Vector3 translation)
    {
        // Burada DecomposeSwingTwist fonksiyonunu implemente etmek i�in gerekli kodu ekleyin
        // Bu �zel bir fonksiyon oldu�u i�in geni�letme y�ntemini uygulayabilirsiniz
        // Bu fonksiyonu Unity'nin built-in fonksiyonlar� kullanarak doldurmak yerine, kendi d�n���m mant���n�z� uygulayabilirsiniz

        scale = Vector3.one;
        rotation = Quaternion.identity;
        translation = Vector3.zero;

        return false; // Fonksiyonu ba�ar�s�z olarak i�aretle, ger�ek implementasyonu yapmal�s�n�z
    }
}

