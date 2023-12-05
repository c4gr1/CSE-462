using UnityEngine;
public static class MatrixExtensions
{
    public static bool DecomposeSwingTwist(Matrix4x4 matrix, Vector3 swingAxis, out Vector3 scale, out Quaternion rotation, out Vector3 translation)
    {
        // Burada DecomposeSwingTwist fonksiyonunu implemente etmek için gerekli kodu ekleyin
        // Bu özel bir fonksiyon olduðu için geniþletme yöntemini uygulayabilirsiniz
        // Bu fonksiyonu Unity'nin built-in fonksiyonlarý kullanarak doldurmak yerine, kendi dönüþüm mantýðýnýzý uygulayabilirsiniz

        scale = Vector3.one;
        rotation = Quaternion.identity;
        translation = Vector3.zero;

        return false; // Fonksiyonu baþarýsýz olarak iþaretle, gerçek implementasyonu yapmalýsýnýz
    }
}

