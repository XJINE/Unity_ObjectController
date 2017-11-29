using UnityEngine;

/// <summary>
/// シングルトンの MonoBehaviour です。
/// </summary>
/// <typeparam name="T">
/// 任意の型 T.
/// </typeparam>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
{
    // NOTE:
    // SingletonMonoBehaviour<T>.instanciated がなくても Singleton の仕様は成り立ちます。
    // ただし繰り返し参照されるときは null よりも bool の方が比較検証が高速です。

    #region Field

    /// <summary>
    /// インスタンス。
    /// </summary>
    protected static T instance;

    /// <summary>
    /// インスタンス化されたかどうか。
    /// </summary>
    protected static bool instanciated;

    #endregion Field

    #region Property

    /// <summary>
    /// インスタンスを取得します。
    /// </summary>
    public static T Instance
    {
        get
        {
            if (SingletonMonoBehaviour<T>.instanciated)
            {
                return instance;
            }

            if (SingletonMonoBehaviour<T>.instance == null)
            {
                SingletonMonoBehaviour<T>.instance = (T)FindObjectOfType(typeof(T));

                if (SingletonMonoBehaviour<T>.instance == null)
                {
                    GameObject gameObject = new GameObject(typeof(T).ToString());
                    SingletonMonoBehaviour<T>.instance = gameObject.AddComponent<T>();
                }
            }

            SingletonMonoBehaviour<T>.instanciated = true;

            return instance;
        }
    }

    /// <summary>
    /// インスタンス化されたかどうかを取得します。
    /// </summary>
    public static bool Instanciated
    {
        get
        {
            return SingletonMonoBehaviour<T>.instanciated;
        }
    }

    #endregion Property

    #region Method

    /// <summary>
    /// 初期化時に呼び出されます。
    /// </summary>
    protected virtual void Awake()
    {
        // NOTE:
        // 初期化時点でインスタンスを生成し、参照時の負荷のバラつきを軽減します。

        if (SingletonMonoBehaviour<T>.instance == null)
        {
            SingletonMonoBehaviour<T>.instance = (T)this;
            SingletonMonoBehaviour<T>.instanciated = true;
        }

        // NOTE:
        // 初期化時に異なるインスタンスが存在するときは、それを削除します。
        // Singleton であるため、コードから呼び出されることはほとんどありませんが、
        // 例えば複数の GameObject にアタッチされる可能性があります。
        // 対象の GameObject に異なる MonoBehaviour がアタッチされる可能性を考慮して、
        // GameObject ごと削除しない点に注意してください。

        else if (SingletonMonoBehaviour<T>.instance != this)
        {
            Debug.LogWarning("Singleton " + typeof(T) + " has another instance.");
            Destroy(this);
        }
    }

    /// <summary>
    /// 破棄時に呼び出されます。
    /// </summary>
    protected virtual void OnDestroy()
    {
        SingletonMonoBehaviour<T>.instanciated = false;
        SingletonMonoBehaviour<T>.instance = null;
    }

    #endregion Method
}