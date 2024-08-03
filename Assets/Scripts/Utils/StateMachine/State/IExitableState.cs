using System.Collections;

namespace Utils
{
    public interface IExitableState
    {
        public void OnExit();
        public void OnUpdate();
    }
}