namespace HotfixBusiness.Entity
{
    public partial class Character
    {
        public IdleState IdleState { get; set; }
        public MoveState MoveState { get; set; }
        public JumpState JumpState { get; set; }
        public void GetCharacterState()
        {
            MoveState = new MoveState();
            IdleState = new IdleState();
            JumpState = new JumpState();
        }
    }
}