using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 色を段階的に制御します。
    /// </summary>
    public class ColorShiftController : ColorController
    {
        // SetNextColor を何かのタイミングで呼び出すたびに色が変わります。

        #region Field

        /// <summary>
        /// 設定する色のリスト。
        /// </summary>
        public List<Color> colors;

        /// <summary>
        /// 設定する色のインデックス。
        /// </summary>
        public int colorIndex = 0;

        /// <summary>
        /// ループするかどうか。
        /// </summary>
        public bool loop = true;

        /// <summary>
        /// Lerp して変化するかどうか。
        /// </summary>
        public bool lerp = true;

        /// <summary>
        /// Lerp して変化するときの時間。
        /// </summary>
        public float lerpDurationSec = 3f;

        /// <summary>
        /// Lerp を開始するときの色。
        /// </summary>
        protected Color lerpStartColor;

        /// <summary>
        /// Lerp を終了するときの色。
        /// </summary>
        protected Color lerpEndColor;

        #endregion Field

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected override void Start()
        {
            base.color = this.colors[this.colorIndex];
            base.Start();
        }

        /// <summary>
        /// 次の色を取得します。
        /// </summary>
        /// <returns>
        /// 次の色。
        /// </returns>
        protected virtual Color GetNextColor()
        {
            this.colorIndex = this.colorIndex + 1;
            int colorsCount = this.colors.Count;

            if (this.colorIndex >= colorsCount)
            {
                if (this.loop)
                {
                    this.colorIndex = this.colorIndex % colorsCount;
                }
                else
                {
                    this.colorIndex = colorsCount - 1;
                }
            }

            return this.colors[colorIndex];
        }

        /// <summary>
        /// 次の色を設定します。
        /// </summary>
        public virtual void SetNextColor()
        {
            if (this.lerp)
            {
                this.lerpStartColor = this.color;
                this.lerpEndColor = GetNextColor();

                StartCoroutine(SetNextColorLerp());
            }
            else
            {
                this.color = GetNextColor();
                base.SetColor(this.color);
            }
        }

        /// <summary>
        /// 次の色を Lerp しながら設定します。
        /// </summary>
        /// <returns>
        /// IEnumerator.
        /// </returns>
        protected virtual IEnumerator SetNextColorLerp()
        {
            float lerpDurationTimeSecCounter = 0;
            float lerpRatio = 0;

            while (true)
            {
                lerpDurationTimeSecCounter += Time.deltaTime;

                lerpRatio = Mathf.Min(1, lerpDurationTimeSecCounter / this.lerpDurationSec);

                if (lerpRatio == 1)
                {
                    yield break;
                }

                this.color = Color.Lerp(this.lerpStartColor, this.lerpEndColor, lerpRatio);

                base.SetColor(this.color);

                // 1 フレームに 1 回だけ実行するようにします。

                yield return new WaitForEndOfFrame();
            }
        }

        #endregion Method
    }
}