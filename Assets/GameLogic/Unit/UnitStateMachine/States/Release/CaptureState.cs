using System;

namespace TestProject.DevOOP.Units.USM
{
    internal sealed class CaptureState : BaseState
    {
        public override void EnterState()
        {
            //throw new NotImplementedException();
            StateDebug("Enter");
        }

        public override Type ExecuteState()
        {
            Type resultStateType = this.GetType();

            return resultStateType;
        }

        public override void ExiteState()
        {
            //throw new NotImplementedException();
            StateDebug("Exit");
        }
    }
}