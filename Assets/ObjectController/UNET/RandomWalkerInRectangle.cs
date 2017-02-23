using UnityEngine;
using UnityEngine.Networking;

namespace ObjectController.UNET
{
    /// <summary>
    /// 直方体の中をランダムに移動させます。
    /// </summary>
    public class RandomWalkerInRectangle : NetworkBehaviour
    {
        #region Field

        /// <summary>
        /// 移動範囲の最小座標(直方体の前方左下)。
        /// </summary>
        public Vector3 moveRangeMin = Vector3.zero;

        /// <summary>
        /// 移動範囲の最大座標(直方体の後方右上)。
        /// </summary>
        public Vector3 moveRangeMax = Vector3.one * 10f;

        /// <summary>
        /// 移動速度。
        /// </summary>
        public float moveSpeed = 5;

        /// <summary>
        /// 移動先。
        /// </summary>
        private Vector3 targetPosition;

        #endregion Field

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Start()
        {
            UpdateTargetPosition();
        }

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                                                          this.targetPosition,
                                                          Time.deltaTime * this.moveSpeed);

            if (this.transform.position == this.targetPosition)
            {
                UpdateTargetPosition();
            }
        }

        /// <summary>
        /// Gizmo の描画時に呼び出されます。
        /// </summary>
        protected virtual void OnDrawGizmos()
        {
            Color previousGizmosColor = Gizmos.color;

            Gizmos.color = Color.white;

            Vector3 moveRange = this.moveRangeMax - this.moveRangeMin;

            Gizmos.DrawWireCube(this.moveRangeMin + (moveRange / 2), moveRange);

            Gizmos.color = previousGizmosColor;
        }

        /// <summary>
        /// 進行方向を決定します。
        /// </summary>
        protected virtual void UpdateTargetPosition()
        {
            this.targetPosition = new Vector3()
            {
                x = Random.Range(this.moveRangeMin.x, this.moveRangeMax.x),
                y = Random.Range(this.moveRangeMin.y, this.moveRangeMax.y),
                z = Random.Range(this.moveRangeMin.z, this.moveRangeMax.z)
            };
        }

        #endregion Method
    }
}