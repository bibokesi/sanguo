using Fantasy;
using UnityEngine;

public class EventStruct
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
