using UnityEngine;
using UnityEngine.Networking;

namespace ObjectController.UNET
{
    /// <summary>
    /// ランダムに回転します。
    /// </summary>
    public class RandomRotator : NetworkBehaviour
    {
        #region Field

        /// <summary>
        /// 回転速度。
        /// </summary>
        public float rotateSpeed = 100;

        /// <summary>
        /// 次の回転を示すクォータニオン。
        /// </summary>
        private Quaternion targetRotation;

        /// <summary>
        /// 直前の回転を示すクォータニオン。
        /// </summary>
        private Quaternion previousQuaternion;

        #endregion Field

        #region Method

        /// <summary>
        /// 開始時に呼び出されます。
        /// </summary>
        protected virtual void Start()
        {
            this.targetRotation     = Random.rotation;
            this.previousQuaternion = base.transform.rotation;
        }

        /// <summary>
        /// 更新時に呼び出されます。
        /// </summary>
        protected virtual void Update()
        {
            this.previousQuaternion = this.transform.rotation;

            this.transform.rotation = Quaternion.RotateTowards(base.transform.rotation,
                                                               this.targetRotation,
                                                               Time.deltaTime * this.rotateSpeed);

            if (base.transform.rotation == this.previousQuaternion
             || this.transform.rotation == this.targetRotation)
            {
                this.targetRotation = Random.rotation;
            }
       }

        #endregion Method
    }
}