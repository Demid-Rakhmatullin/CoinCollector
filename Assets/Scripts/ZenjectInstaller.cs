using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    [SerializeField] private PlayerCoinCollector playerCoins;

    public override void InstallBindings()
    {
        Container.BindInstance(playerCoins);
    }
}