using UnityEngine;

public class DebugExSample : MonoBehaviour
{
    void Start()
    {
        DebugEx.Log("HERE1 : " + Vector3.zero);
        DebugEx.Log("HERE2 : " + Vector3.zero, ", ");
        DebugEx.Log("HERE3 : " + Vector3.zero, 0.01f, ", ");
        DebugEx.Log("HERE4 : " + Vector3.zero, 0.01f, base.name, ", ");
    }
}