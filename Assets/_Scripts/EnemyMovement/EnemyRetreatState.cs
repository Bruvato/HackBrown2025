using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;


public class EnemyRetreatState : IMoveState
{
    Enemy owner; 
    EnemyRetreat function;
    public EnemyRetreatState(Enemy owner) { this.owner = owner; }
    public void Enter()
    {
        function = owner.AddComponent<EnemyRetreat>();
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        function.DestroySelf();
    }
    
}