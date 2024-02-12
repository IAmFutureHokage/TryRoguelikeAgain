using Ruguelike.GameObjects;

namespace Ruguelike.GameCore.EventManager
{
    public interface IEventManager
    {
        void SubscribeToAttack(Action<IDynamicObject, IDynamicObject> subscriber);
        void UnsubscribeFromAttack(Action<IDynamicObject, IDynamicObject> subscriber);
        void UpdateSenders();
    }
}
