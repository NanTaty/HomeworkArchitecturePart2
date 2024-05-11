using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindLoader();
    }
    
    private void BindLoader()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
    }
}
