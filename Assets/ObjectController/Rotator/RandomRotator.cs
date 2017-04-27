using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// ランダムに回転します。
    /// </summary>
    public class RandomRotator : MonoBehaviour
    {
        #region Field

        /// <summary>
        /// 回転する軸。
        /// </summary>
        protected Vector3 rotateAxis;

        /// <summary>
        /// 回転する速度(角度)。
        /// </summary>
        public float rotateSpeedDegree = 1;

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
        protected virtual void Update()
        {
            this.rotateTimeSecCounter += Time.deltaTime;

            if (this.rotateTimeSec < this.rotateTimeSecCounter)
            {
                this.rotateTimeSecCounter = 0;
                UpdateRotateAxis();
            }

            base.transform.RotateAround(base.transform.position,
                                        this.rotateAxis,
                                        this.rotateSpeedDegree);
        }

        /// <summary>
        /// 回転軸を更新します。
        /// </summary>
        protected virtual void UpdateRotateAxis()
        {
            this.rotateAxis = new Vector3(Random.value, Random.value, Random.value);
        }


        #endregion Method
    }
}