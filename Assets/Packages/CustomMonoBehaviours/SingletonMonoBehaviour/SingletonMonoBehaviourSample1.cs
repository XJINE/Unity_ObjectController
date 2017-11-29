using UnityEngine;
using System.Collections;

/// <summary>
/// シングルトンの MonoBehaviour のサンプルです。
/// </summary>
public class SingletonMonoBehaviourSample1 : SingletonMonoBehaviour<SingletonMonoBehaviourSample1>
{
    public int value = 0;
}