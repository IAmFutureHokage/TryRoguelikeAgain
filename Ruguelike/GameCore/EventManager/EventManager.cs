using Ruguelike.GameObjects;
using Ruguelike.GameSceneRepository;

namespace Ruguelike.GameCore.EventManager
{
    public class EventManager(IGameSceneRepository gameSceneRepository) : IEventManager
    {
        private readonly IGameSceneRepository gameSceneRepository = gameSceneRepository;
        private Action<IDynamicObject, IDynamicObject>? onAttackSubscription;

        public void SubscribeToAttack(Action<IDynamicObject, IDynamicObject> subscriber)
        {
            onAttackSubscription += subscriber;
        }

        public void UnsubscribeFromAttack(Action<IDynamicObject, IDynamicObject> subscriber)
        {
            onAttackSubscription -= subscriber;
        }

        public void DispatchAttack(IDynamicObject attacker, IDynamicObject target)
        {
            onAttackSubscription?.Invoke(attacker, target);
        }

        public void UpdateSenders()
        {
            var currentDynamicObjects = gameSceneRepository.GameObjects(obj => obj is IDynamicObject).Cast<IDynamicObject>();
            foreach (var dynamicObject in currentDynamicObjects)
            {
                dynamicObject.Weapon.OnAttack -= DispatchAttack;
            }

            foreach (var dynamicObject in currentDynamicObjects)
            {
                dynamicObject.Weapon.OnAttack += DispatchAttack;
            }
        }
    }
}
