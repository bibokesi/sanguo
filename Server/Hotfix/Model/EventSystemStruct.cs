using Fantasy;
using UnityEngine;

public class EventSystemStruct
{
    public struct StartMove
    {
        public PlayerEntity playerEntity;
        public MoveInfo moveInfo;
        public StartMove()
        {
            playerEntity = null;
            moveInfo = null;
        }
    }
}
