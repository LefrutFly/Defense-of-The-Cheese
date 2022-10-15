using UnityEngine;

public class EnemyDirectionFinderSystem : BaseSystem, IUpdatableSystem
{
    public void Update()
    {
        if (IsActive == false) return;

        if(Providers.Has<DirectionProvider>() == false ||
            Providers.Has<EnemyProvider>() == false) 
            return;

        var directionComponent = Providers.Get<DirectionProvider>().component;

        var player = Providers.Get<EnemyProvider>().component.Player;

        FindeDirectionToPlayer(directionComponent, player);
    }

    private void FindeDirectionToPlayer(DirectionComponent directionComponent, Player player)
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 enemyPosition = Actor.transform.position;

        directionComponent.Direction = enemyPosition.FindDirectionPointToPoint(playerPosition); 
    }
}