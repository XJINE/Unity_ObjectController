using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// ランダムに回転します。
    /// </summary>
    public class RandomAxisRotator : AxisRotator
    {
        #region Field

        /// <summary>
        /// 同じ方向に回転している時間。
        /// </summary>
        public float rotateTimeSec = 2;

        /// <summary>
        /// 回転している時間のカウンタ。
        /// </summary>
        protected float rotateTimeSecCounter;

        #endregion Field

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Start()
        {
            UpdateRotateAxis();
        }

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected override void Update()
        {
            this.rotateTimeSecCounter += Time.deltaTime;

            if (this.rotateTimeSec < this.rotateTimeSecCounter)
            {
                this.rotateTimeSecCounter = 0;
                UpdateRotateAxis();
            }

            base.Update();
        }

        /// <summary>
        /// 回転します。
        /// </summary>
        /// <returns>
        /// 回転した量(degree)。
        /// </returns>
        protected override float Rotate()
        {
            float rotateAngleDegree = base.rotateSpeed * Time.deltaTime;

            base.transform.RotateAround(base.transform.position,
                                        this.rotateAxis,
                                        rotateAngleDegree);

            return rotateAngleDegree;
        }

        /// <summary>
        /// 回転軸を更新します。
        /// </summary>
        protected virtual void UpdateRotateAxis()
        {
            base.rotateAxis = new Vector3(Random.value, Random.value, Random.value);
        }

        #endregion Method
    }
}