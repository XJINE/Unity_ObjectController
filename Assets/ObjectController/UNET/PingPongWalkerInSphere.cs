using UnityEngine;
using UnityEngine.Networking;

namespace ObjectController.UNET
{
    /// <summary>
    /// 球の中をランダムに跳ね返りながら移動させます。
    /// </summary>
    public class PingPongWalkerInSphere : NetworkBehaviour
    {
        #region Field

        /// <summary>
        /// 移動範囲の原点。
        /// </summary>
        public Vector3 moveOrigin;

        /// <summary>
        /// 移動範囲の半径。
        /// </summary>
        public float moveRangeRadius = 5;

        /// <summary>
        /// 移動速度。
        /// </summary>
        public float moveSpeed = 5;

        /// <summary>
        /// 移動先。
        /// </summary>
        protected Vector3 targetPosition;

        #endregion Field

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Awake()
        {
            UpdateTargetPosition();
        }

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            base.transform.position = Vector3.MoveTowards(base.transform.position,
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

            Gizmos.DrawWireSphere(this.moveOrigin, this.moveRangeRadius);

            Gizmos.color = previousGizmosColor;
        }

        /// <summary>
        /// 進行方向を決定します。
        /// </summary>
        protected virtual void UpdateTargetPosition()
        {
            this.targetPosition = this.moveOrigin + Random.onUnitSphere * this.moveRangeRadius;
        }

        #endregion Method
    }
}