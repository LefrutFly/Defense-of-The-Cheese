using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStateMachine : StateMachine
{
    [Inject] private Player player;
    [Inject] private Tower tower;
    [Inject] private Screens screens;
    [Inject] private EnemySpawner enemySpawner;
    [Inject] private Statistics statistics;
    [Inject] private Timer timer;

    public Player Player => player;
    public Tower Tower => tower;
    public Screens Screens => screens;
    public EnemySpawner EnemySpawner => enemySpawner;
    public Statistics Statistics => statistics;
    public Timer Timer => timer;


    private void Start()
    {
        SetState(new BeginState(this));
    }
}
