using UnityEngine;

namespace ObjectController
{
    /// <summary>
    /// Cos の軌道 (-1 ~ 1) で動きます。
    /// </summary>
    public class CosMover : MonoBehaviour
    {
        #region Field

        /// <summary>
        /// 基準点。
        /// </summary>
        public Vector3 basePosition = Vector3.zero;

        /// <summary>
        /// 移動する方向。
        /// </summary>
        public Vector3 direction = Vector3.right;

        /// <summary>
        /// 移動する速度。
        /// </summary>
        public float speed = 1;

        /// <summary>
        /// 移動する大きさ。
        /// </summary>
        public float scale = 2;

        #endregion Field

        #region Method

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            base.transform.position = this.basePosition
                                    + Vector3.Normalize(this.direction)
                                    * Mathf.Cos(Time.time * speed)
                                    * scale;
        }

        #endregion Method
    }
}