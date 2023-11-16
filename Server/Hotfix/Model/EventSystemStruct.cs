using Fantasy;
using UnityEngine;

public class EventSystemStruct
{
    public struct StartMove
    {
        public Unit unit;
        public MoveInfo moveInfo;
        public StartMove()
        {
            unit = null;
            moveInfo = null;
        }
    }
}
