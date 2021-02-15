namespace TestProject.DevOOP.Units.USM
{
    internal interface IUnitStateMachine<T>
    {
        IState<T> ProcessUSM(IState<T> currenState, T sender);
    }
}