using System.Collections;

namespace Utils
{
    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        public void OnEnter(TPayLoad payLoad);
    }
}