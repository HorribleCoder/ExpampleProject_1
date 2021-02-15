namespace TestProject.DevOOP
{
    public enum DebugColor
    {
        black,
        red,
        blue,
        green,
        orange,
        white,
    }
    /// <summary>
    /// Debug your message in Unity Console&. Can use Color!
    /// </summary>
    public static class _Debug
    {
        public static bool isShowLog = true;
        /// <summary>
        /// Write message-log in Console
        /// </summary>
        /// <param name="message">Something message</param>
        /// <param name="color">Color your message if need, default color-White </param>
        public static void Log(object message, DebugColor color = DebugColor.white)
        {
            if (!isShowLog) return;
            UnityEngine.Debug.Log($"<color={color.ToString()}><size=12><color=white>CUSTOM_DEBUG >>></color></size> Message - {message}.</color>");
        }
    }
}