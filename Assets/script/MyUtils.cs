using UnityEngine;
using System.Collections;

public class MyUtils : MonoBehaviour
{
    public enum GameState { Ing, End };
    public enum ObjState { Start, Moving, Out };

    public static class GameType
    {
        public const int Classics = 1;
        public const int DBclick = 2;
        public const int Timer = 3;
        public const int RollerCoaster = 4;
        public const int TwoHand = 5;
        public const int PlusOne = 6;

    }

    // Use this for initialization


}
