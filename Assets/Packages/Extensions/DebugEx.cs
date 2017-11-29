using UnityEngine;

/// <summary>
/// Debug に関する拡張機能を実装します。
/// </summary>
public static class DebugEx
{
    /// <summary>
    /// 複数のメッセージを messages[length - 1] で区切ってデバッグ出力します。
    /// </summary>
    /// <param name="message">
    /// 出力するメッセージ。
    /// </param>
    /// <param name="messages">
    /// 出力するメッセージ。
    /// [messages.length - 1] 番目のメッセージで各メッセージを区切ります。
    /// </param>
    public static void Log(object message, params object[] messages)
    {
        int messagesLength = messages.Length;

        if (messagesLength == 0)
        {
            Debug.Log(message);
            return;
        }

        string split = messages[messagesLength - 1].ToString();

        for (int i = 0; i < messagesLength - 1; i++)
        {
            message += split + messages[i];
        }

        Debug.Log(message);
    }
}