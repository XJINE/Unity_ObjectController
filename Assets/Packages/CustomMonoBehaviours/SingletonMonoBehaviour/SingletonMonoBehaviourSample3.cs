using UnityEngine;

public class SingletonMonoBehaviourSample3 : MonoBehaviour
{
    /// <summary>
    /// 開始時に呼び出されます。
    /// </summary>
    protected virtual void Start ()
    {
        SingletonMonoBehaviourSample1.Instance.value += 1;
        Debug.Log(this.GetType().ToString() + " : " + SingletonMonoBehaviourSample1.Instance.value);
    }
}