using UnityEngine;

public class EnemyDirectionFinderSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (IsActive == false) return;

        if (Providers.Has<DirectionProvider>() == false ||
            Providers.Has<EnemyProvider>() == false)
            return;

        var directionComponent = Providers.Get<DirectionProvider>().component;
        var enemyComponent = Providers.Get<EnemyProvider>().component;

        var playerPoint = enemyComponent.Player.transform.position;
        var towerPoint = enemyComponent.Tower.transform.position;
        var distance = enemyComponent.distanceToTowerForVision;


        if(FindDistanceToTarget(towerPoint) <= distance)
        {
            FindDirectionToTarget(directionComponent, towerPoint);
        }
        else
        {
            if (FindDistanceToTarget(playerPoint) <= distance)
            {
                FindDirectionToTarget(directionComponent, playerPoint);
            }
            else
            {
                FindDirectionToTarget(directionComponent, towerPoint);
            }
        }
    }

    private void FindDirectionToTarget(DirectionComponent directionComponent, Vector3 targetPoint)
    {
        Vector2 enemyPosition = Actor.transform.position;

        directionComponent.Direction = enemyPosition.FindDirectionPointToPoint(targetPoint);
    }

    private float FindDistanceToTarget(Vector3 targetPoint)
    {
        float distance = 0;

        Vector2 enemyPosition = Actor.transform.position;

        distance = Vector2.Distance(enemyPosition, targetPoint);

        return distance;
    }
}