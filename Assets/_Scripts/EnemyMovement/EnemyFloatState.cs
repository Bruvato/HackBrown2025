using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;


public class EnemyFloatState : IMoveState
{
    Enemy owner; 
    EnemyFloat function;
    public EnemyFloatState(Enemy owner) { this.owner = owner; }
    public void Enter()
    {
        function = owner.AddComponent<EnemyFloat>();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        function.DestroySelf();
    }
    
}