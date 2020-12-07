using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum CameraMode
    {
        QuaterView,
        FPS
    }

    public enum MouseEvent
    {
        Down_0,
        Press_0,
        Up_0
    }

    public enum Audio
    {
        BGM,
        Effect,
        MaxCount,
    }


}
