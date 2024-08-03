using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Utils
{
    public class StateMachine
    {
        public IExitableState CurrentState { get; private set; }

        private readonly Dictionary<Type, IExitableState> states = new();

        public void EnterState<T>() where T : IState
        {
            T newState = GetState<T>();
            if (newState == null)
                return;

            ChangeState(newState);
            newState.OnEnter();
        }

        public void EnterState<T, TPayLoad>(TPayLoad payLoad) where T : IPayLoadedState<TPayLoad>
        {
            T newState = GetState<T>();
            if (newState == null)
                return;

            ChangeState(newState);
            newState.OnEnter(payLoad);
        }

        public void AddState(IExitableState state)
        {
            Type type = state.GetType();
            states[type] = state;
        }

        public T GetState<T>() where T : IExitableState
        {
            if (!states.ContainsKey(typeof(T)))
            {
                Debug.LogError("Can't get state: " + typeof(T) + " - StateMachine doesn't contain this state");
                return default;
            }

            return (T)states[typeof(T)];
        }

        private void ChangeState(IExitableState newState)
        {
            if (CurrentState != null)
            {
                CurrentState.OnExit();
            }

            CurrentState = newState;
        }
    }
}