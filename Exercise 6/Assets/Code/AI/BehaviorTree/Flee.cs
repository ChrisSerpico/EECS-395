using UnityEngine;

/// <summary>
/// Behavior that runs to a random location
/// </summary>
public class Flee : BehaviorTreeNode
{
    /// <summary>
    /// Where we're running to
    /// </summary>
    private Vector3 goal;
    const float GoalThreshold = 1;

    public override void Activate(AITankControl tank)
    {
        bool isValid = false;

        while (!isValid)
        {
            goal = SpawnController.FindFreeLocation(tank.GetComponent<BoxCollider2D>().size.magnitude);

            if (!BehaviorTreeNode.WallBetween(tank.transform.position, goal))
            {
                isValid = true;
            }
        }
    }

    /// <summary>
    /// Run toward the goal
    /// </summary>
    /// <param name="tank">Tank being controlled</param>
    /// <returns>True if behavior wants to keep running</returns>
    public override bool Tick(AITankControl tank)
    {
        tank.MoveTowards(goal);
        if (Vector3.Distance(tank.transform.position, goal) <= GoalThreshold)
            return false;
        else
            return true; 
    }
}
