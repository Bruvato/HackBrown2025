using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public interface IMoveState
{
    public void Enter();
    public void Execute();
    public void Exit();
}

public class EnemyMoveStateMachine
{
    IMoveState currentState;

    public void ChangeState(IMoveState newState)
    {
        if (currentState != newState)
        {
            if (currentState != null)
                currentState.Exit();

            currentState = newState;
            currentState.Enter();
        }
    }

    public void Update()
    {
        if (currentState != null) currentState.Execute();
    }
}


