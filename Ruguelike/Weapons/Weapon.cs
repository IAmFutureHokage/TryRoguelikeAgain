using Ruguelike.CustomStructures;
using Ruguelike.GameObjects;

namespace Ruguelike.Weapons
{
    public class Weapon(string name, int damage, Action<IDynamicObject, IDynamicObject> attackAction, Func<Position, Func<IGameObject, bool>> getTargetPredicate) : IWeapon
    {
        public event Action<IDynamicObject, IDynamicObject>? OnAttack;
        private readonly Action<IDynamicObject, IDynamicObject> attackAction = attackAction;
        private readonly Func<Position, Func<IGameObject, bool>> getTargetPredicate = getTargetPredicate;
        public string Name { get; } = name;
        public int Damage { get; } = damage;

        public void Attack(IDynamicObject attacker, IDynamicObject target)
        {
            attackAction(attacker, target);
            OnAttack?.Invoke(attacker, target);
        }

        public Func<IGameObject, bool> GetTargetPredicate(Position playerPosition)
        {
            return getTargetPredicate(playerPosition);
        }
    }
}
