using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private DefeatPanel _defeatPanel;
    public override void InstallBindings()
    {
        Container.Bind<Level>().AsSingle();
        Container.Bind<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();
        Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle();
    }
}
