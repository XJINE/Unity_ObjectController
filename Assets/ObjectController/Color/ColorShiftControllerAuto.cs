using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 色を段階的に制御します。
    /// </summary>
    public class ColorShiftControllerAuto : ColorShiftController
    {
        #region Field

        /// <summary>
        /// 色を変えるインターバル。
        /// </summary>
        public float intervalSec = 5f;

        /// <summary>
        /// 色を変えるインターバールのカウンタ。
        /// </summary>
        public float intervalSecCounter = 0;

        #endregion Field

        #region Method

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            this.intervalSecCounter += Time.deltaTime;

            if (this.intervalSec < this.intervalSecCounter)
            {
                base.SetNextColor();
                this.intervalSecCounter = 0;
            }
        }

        #endregion Method
    }
}