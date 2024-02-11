using Ruguelike.CustomStructures;
using Ruguelike.GameObjects;

namespace Ruguelike.Weapons
{
    public interface IWeapon
    {
        void Attack(IDynamicObject attacker, IDynamicObject target);
        Func<IGameObject, bool> GetTargetPredicate(Position playerPosition);
    }
}
