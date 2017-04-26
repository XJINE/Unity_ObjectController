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
        public float moveSpeed = 1;

        /// <summary>
        /// 目的地の方を向くかどうか。
        /// </summary>
        public bool lookAtTarget = true;

        /// <summary>
        /// 回転速度。
        /// </summary>
        public float rotationSpeed = 1;

        /// <summary>
        /// 目的地に到着したときのイベントハンドラ。
        /// </summary>
        public UnityEvent arrivedEventHandler;

        #endregion Field

        #region Method

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
            Vector3 position = Vector3.MoveTowards
                (this.transform.position, this.target, Time.deltaTime * this.moveSpeed);

            if (this.lookAtTarget)
            {
                Vector3 direction   = this.target - position;
                Quaternion rotation = Quaternion.LookRotation(direction);

                base.transform.rotation = Quaternion.Slerp(base.transform.rotation,
                                                           rotation,
                                                           Time.deltaTime * this.rotationSpeed);
            }

            base.transform.position = position;

            return position == this.target;
        }

        /// <summary>
        /// 目的地に到着したときの処理を実行します。目的地に到着したときだけ呼び出します。
        /// arrivalEventHandler が実行されます。
        /// </summary>
        protected void Arrived()
        {
            this.arrivedEventHandler.Invoke();
        }

        #endregion Method
    }
}