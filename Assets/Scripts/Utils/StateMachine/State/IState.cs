using System.Collections;

namespace Utils
{
    public interface IState : IExitableState
    {
        public void OnEnter();
    }
}