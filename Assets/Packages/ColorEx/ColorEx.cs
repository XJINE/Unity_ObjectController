using UnityEngine;

namespace ColorEx
{
    /// <summary>
    /// UnityEngine.Color クラスの拡張メソッドを実装します。
    /// </summary>
    public static class ColorEx
    {
        /// <summary>
        /// HSV Color に変換します。
        /// </summary>
        /// <param name="rgbColor">
        /// HSV Color に変換する RGB Color.
        /// </param>
        /// <returns>
        /// HSV Color.
        /// </returns>
        public static HSVColor ToHSVColor(this Color rgbColor)
        {
            return new HSVColor(rgbColor);
        }
    }
}