namespace TestProject.DevOOP.Units.USM
{
    internal abstract class BaseState: IState<BaseGameUnit>
    {
        protected BaseGameUnit owner;
        public void SetUnitOwner(BaseGameUnit owner)
        {
            this.owner = owner;
        }
        public abstract void EnterState();
        public abstract System.Type ExecuteState();
        public abstract void ExiteState();

        //TODO удалить позже, так как это только для дебага
        protected virtual void StateDebug(object message)
        {
            _Debug.Log($"State - {GetType().Name} is {message}");
        }
    }
}