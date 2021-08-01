using System;
using UnityEngine;

public class DebugLogUtil
{
    public static void log(Type type, string message)
    {
        Debug.Log(type.Name + " " + message);
    }
}