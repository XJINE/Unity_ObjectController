using UnityEngine;

namespace ColorEx
{
    /// <summary>
    /// HSV で表現される色の構造体です。
    /// </summary>
    public struct HSVColor
    {
        #region Field

        /// <summary>
        /// Hue.
        /// </summary>
        public float h;

        /// <summary>
        /// Satulatin.
        /// </summary>
        public float s;

        /// <summary>
        /// Value.
        /// </summary>
        public float v;

        /// <summary>
        /// Alpha.
        /// </summary>
        public float a;

        /// <summary>
        /// 変換用の一時的な変数。
        /// </summary>
        private static float tempH, tempS, tempV;

        #endregion Field

        #region Constructor

        /// <summary>
        /// 新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="rgbColor">
        /// HSV Color に変換する RGB Color.
        /// </param>
        public HSVColor(Color rgbColor)
        {
            Color.RGBToHSV(rgbColor, out tempH, out tempS, out tempV);

            this.h = tempH;
            this.s = tempS;
            this.v = tempV;
            this.a = rgbColor.a;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// HSV パラメータを CSV 形式の文字列にして返します。
        /// </summary>
        /// <returns>
        /// CSV 文字列。
        /// </returns>
        public override string ToString()
        {
            return h + ", " + s + ", " + v + ", " + a;
        }

        /// <summary>
        /// RGB Color を取得します。
        /// </summary>
        /// <returns>
        /// RGB Color.
        /// </returns>
        public Color ToRGBColor()
        {
            Color rgbColor = Color.HSVToRGB(this.h, this.s, this.v);
            rgbColor.a = this.a;

            return rgbColor;
        }

        /// <summary>
        /// GrayScale Color にします。
        /// </summary>
        /// <returns>
        /// GrayScale Color にします。
        /// </returns>
        public HSVColor ToGrayScale()
        {
            return new HSVColor()
            {
                h = this.h,
                s = 0,
                v = this.v,
                a = this.a
            };
        }

        /// <summary>
        /// H 成分を Lerp します。
        /// </summary>
        /// <param name="to">
        /// 最終的な値。
        /// </param>
        /// <param name="ratio">
        /// 変化率。
        /// </param>
        public void Lerp(HSVColor to, float ratio)
        {
            LerpH(to.h, ratio);
            LerpH(to.s, ratio);
            LerpH(to.v, ratio);
        }

        /// <summary>
        /// H 成分を Lerp します。
        /// </summary>
        /// <param name="to">
        /// 最終的な値。
        /// </param>
        /// <param name="ratio">
        /// 変化率。
        /// </param>
        public void LerpH(float to, float ratio)
        {
            this.h = Mathf.Lerp(this.h, to, ratio);
        }

        /// <summary>
        /// S 成分を Lerp します。
        /// </summary>
        /// <param name="to">
        /// 最終的な値。
        /// </param>
        /// <param name="ratio">
        /// 変化率。
        /// </param>
        public void LerpS(float to, float ratio)
        {
            this.s = Mathf.Lerp(this.s, to, ratio);
        }

        /// <summary>
        /// V 成分を Lerp します。
        /// </summary>
        /// <param name="to">
        /// 最終的な値。
        /// </param>
        /// <param name="ratio">
        /// 変化率。
        /// </param>
        public void LerpV(float to, float ratio)
        {
            this.v = Mathf.Lerp(this.v, to, ratio);
        }

        #endregion Method
    }
}