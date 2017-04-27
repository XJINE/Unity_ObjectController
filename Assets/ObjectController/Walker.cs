using UnityEngine;
using UnityEngine.Events;

namespace ObjectController
{
    /// <summary>
    /// 目的地に向かって移動します。
    /// </summary>
    public class Walker : MonoBehaviour
    {
        #region Field

        /// <summary>
        /// 目的地。
        /// </summary>
        public Vector3 target = Vector3.zero;

        /// <summary>
        /// 移動速度。
        /// </summary>
        public float moveSpeed = 10;

        /// <summary>
        /// 目的地の方を向くかどうか。
        /// </summary>
        public bool lookAtTarget = true;

        /// <summary>
        /// 回転速度。
        /// </summary>
        public float rotationSpeed = 10;

        /// <summary>
        /// 次の目的地に行くかどうか。
        /// </summary>
        public bool goToNextTarget = true;

        /// <summary>
        /// 目的地に到着したときのイベントハンドラ。
        /// </summary>
        public UnityEvent arrivedEventHandler;

        #endregion Field

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Start()
        {
            if (this.lookAtTarget)
            {
                base.transform.LookAt(this.target);
            }
        }

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            if (Walk())
            {
                Arrived();
            }
        }

        /// <summary>
        /// 移動します。
        /// </summary>
        /// <returns>
        /// 目的地に到着したとき true, それ以外のとき false.
        /// </returns>
        protected virtual bool Walk()
        {
            Vector3 currentPosition = base.transform.position;

            if (currentPosition == this.target && this.goToNextTarget)
            {
                SetNextTarget();
            }

            Vector3 nextPosition = Vector3.MoveTowards
                (currentPosition, this.target, Time.deltaTime * this.moveSpeed);

            if (this.lookAtTarget && this.target != nextPosition)
            {
                Vector3 direction = this.target - nextPosition;
                Quaternion rotation = Quaternion.LookRotation(direction);

                base.transform.rotation = Quaternion.Slerp(base.transform.rotation,
                                                           rotation,
                                                           Time.deltaTime * this.rotationSpeed);
            }

            base.transform.position = nextPosition;

            return nextPosition == this.target && currentPosition != this.target;
        }

        /// <summary>
        /// 目的地に到着したときの処理を実行します。目的地に到着したときだけ呼び出します。
        /// arrivalEventHandler が実行されます。
        /// </summary>
        protected void Arrived()
        {
            this.arrivedEventHandler.Invoke();
        }

        /// <summary>
        /// 次のターゲットの座標を設定します。
        /// </summary>
        protected void SetNextTarget()
        {
            this.target = GetNextTarget();
        }

        /// <summary>
        /// 次のターゲットの座標を取得します。
        /// </summary>
        /// <returns>
        /// 次のターゲットの座標。
        /// </returns>
        protected virtual Vector3 GetNextTarget()
        {
            // この Class ではターゲットを更新しません。

            return this.target;
        }

        #endregion Method
    }
}