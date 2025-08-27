using UnityEngine;
using SongLib;

public abstract class PlayerBaseState : CreatureState<PlayerController>
{
    public abstract override void Enter(object param);
    public abstract override void Exit();
    public abstract override void Tick(float deltaTime); 


}