using Zenject;

public class StatisticsInstaller : MonoInstaller
{
    private Statistics statistics = new Statistics();

    public override void InstallBindings()
    {
        Container.Bind<Statistics>().
            FromInstance(statistics).
            AsSingle().
            NonLazy();
    }
}