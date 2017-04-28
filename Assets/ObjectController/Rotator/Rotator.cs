using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// 回転します。
    /// </summary>
    public class Rotator : MonoBehaviour
    {
        #region Field

        /// <summary>
        /// 回転する速度(角度)。
        /// </summary>
        public float rotateSpeed = 300;

        /// <summary>
        /// 直前の回転速度(角度)
        /// </summary>
        private float previousRotateSpeed = 0;

        /// <summary>
        /// 回転した角度(degree)。
        /// </summary>
        private float totalRotateAngleDegree = 0;

        #endregion Field

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            UpdateTotalRotateDegree(Rotate());
        }

        /// <summary>
        /// 回転します。
        /// </summary>
        /// <returns>
        /// 回転した量(degree)。
        /// </returns>
        protected virtual float Rotate()
        {
            return 0;
        }

        /// <summary>
        /// これまでに回転した量を更新します。
        /// </summary>
        /// <param name="rotateAngleDegree">
        /// 回転した角度(degree)。
        /// </param>
        protected void UpdateTotalRotateDegree(float rotateAngleDegree)
        {
            // 回転速度が変わったら回転量を初期化します。

            if (this.rotateSpeed != this.previousRotateSpeed)
            {
                this.totalRotateAngleDegree = 0;
                this.previousRotateSpeed = this.rotateSpeed;
            }

            this.totalRotateAngleDegree += rotateAngleDegree;

            if (this.rotateSpeed > 0)
            {
                if (360 < this.totalRotateAngleDegree)
                {
                    this.totalRotateAngleDegree -= 360;
                }
            }
            else
            {
                if (this.totalRotateAngleDegree < -360)
                {
                    this.totalRotateAngleDegree += 360;
                }
            }
        }
    }
}