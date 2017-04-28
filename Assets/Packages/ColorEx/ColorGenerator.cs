using UnityEngine;

public class ColorGenerator : MonoBehaviour
{
    /// <summary>
    /// 開始時に呼び出されます。
    /// </summary>
    protected virtual void Start ()
    {
        Debug.Log(GetStandardHueColors360Code());
    }
    
    /// <remarks>
    /// 開発者向けのメソッドです。
    /// </remarks>
    /// <summary>
    /// StandardHueColor360 を定義するためのコードを取得します。
    /// </summary>
    /// <returns>
    /// StandardHueColor360 を定義するコード。
    /// </returns>
    private static string GetStandardHueColors360Code
        (string format = "new Color({0}, {1}, {2}, {3}),")
    {
        string result = "";

        for (int i = 0; i <= 359; i++)
        {
            Color rgbColor = Color.HSVToRGB((i / 359f), 1, 1);

            result += string.Format(format,
                                    rgbColor.r,
                                    rgbColor.g,
                                    rgbColor.b,
                                    rgbColor.a);
        }

        return result;
    }
}