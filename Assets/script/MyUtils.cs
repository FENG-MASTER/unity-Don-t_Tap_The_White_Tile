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
        public const int Half = 7;
        public const int TwoHand_RollerCoaster = 8;
        public const int Reverse = 9;
        public const int Chaos = 10;
        public static string getGameTypeName(int type)
        {
            string name = "";
            switch (type)
            {
                case MyUtils.GameType.Classics:
                    name = "经典模式";
                    break;
                case MyUtils.GameType.DBclick:
                    name = "爆破模式";
                    break;
                case MyUtils.GameType.PlusOne:
                    name = "加一模式";
                    break;
                case MyUtils.GameType.RollerCoaster:
                    name = "过山车模式";
                    break;
                case MyUtils.GameType.Timer:
                    name = "计时模式";
                    break;
                case MyUtils.GameType.TwoHand:
                    name = "双手模式";
                    break;
                case MyUtils.GameType.Half:
                    name = "减半模式";
                    break;
                case MyUtils.GameType.TwoHand_RollerCoaster:
                    name = "双手过山车模式";
                    break;
                case MyUtils.GameType.Reverse:
                    name = "相反模式";
                    break;
                case MyUtils.GameType.Chaos:
                    name = "混沌模式";
                    break;
                default:
                    name = "未知模式,你确定你应该到这里?";
                    break;

            }
            return name;

        }
    
    }


    // Use this for initialization


}
