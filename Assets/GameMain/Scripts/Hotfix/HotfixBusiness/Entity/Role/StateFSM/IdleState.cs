namespace HotfixBusiness.Entity
{
    public class IdleState : State
    {
        protected internal override void OnEnter(StateController stateController)
        {
            base.OnEnter(stateController);

            stateController.Owner.Animator.CrossFade("Idle", 0.1f);
        }

        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
        }

        protected internal override void OnLeave()
        {
            base.OnLeave();
        }
    }
}