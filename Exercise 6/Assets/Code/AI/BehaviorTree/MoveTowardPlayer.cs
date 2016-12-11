/// <summary>
/// Beavhior that drives in a straight line toward the player.
/// </summary>
/// 

using UnityEngine;

public class MoveTowardPlayer : BehaviorTreeNode
{
    public override bool Tick (AITankControl tank) {
        tank.MoveTowards(GameObject.Find("Player").transform.position);
        return false;
    }
}
