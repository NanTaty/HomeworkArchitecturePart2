using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private BallSpawner _ballSpawner;
    [SerializeField] private GameOverPanel _gameOverPanel;

    [Inject] private LevelLoadingData _levelLoadingData;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BallSpawner>().FromInstance(_ballSpawner).AsSingle();
        Container.BindInterfacesAndSelfTo<BallListManager>().AsSingle();
        
        BindWinCondition();
        
        Container.BindInterfacesAndSelfTo<GameClicker>().AsSingle();
        
        BindUI();
    }

    private void BindUI()
    {
        Container.Bind<GameOverPanel>().FromInstance(_gameOverPanel).AsSingle().NonLazy();
        Container.Bind<BallGameMediator>().AsSingle().NonLazy();
    }

    private void BindWinCondition()
    {
        if (_levelLoadingData.GameType == GameType.AllColors)
        {
            Container.Bind<VictoryCondition>().To<AllColorsWinCondition>().AsSingle().NonLazy();
        }
        else if (_levelLoadingData.GameType == GameType.OneColor)
        {
            Container.Bind<VictoryCondition>().To<OneColorWinCondition>().AsSingle().NonLazy();
        }
    }
}
