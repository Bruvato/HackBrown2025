using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;


public class EnemyChaseState : IMoveState
{
    Enemy owner; 
    EnemyChase function;
    public EnemyChaseState(Enemy owner) { this.owner = owner; }
    public void Enter()
    {
        function = owner.AddComponent<EnemyChase>();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        function.DestroySelf();
    }
    
}