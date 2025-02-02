using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;


public class EnemyOrbitState : IMoveState
{
    Enemy owner; 
    EnemyOrbit function;
    public EnemyOrbitState(Enemy owner) { this.owner = owner; }
    public void Enter()
    {
        function = owner.AddComponent<EnemyOrbit>();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        function.DestroySelf();
    }
    
}