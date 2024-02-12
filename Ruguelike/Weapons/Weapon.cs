using Ruguelike.CustomStructures;
using Ruguelike.GameObjects;

namespace Ruguelike.Weapons
{
    public class Weapon(string name, int damage, Action<IDynamicObject, IDynamicObject> attackAction, Func<Position, Func<IGameObject, bool>> getTargetPredicate) : IWeapon
    {
        private readonly Action<IDynamicObject, IDynamicObject> _attackAction = attackAction;
        private readonly Func<Position, Func<IGameObject, bool>> _getTargetPredicate = getTargetPredicate;
        public string Name { get; } = name;
        public int Damage { get; } = damage;

        public void Attack(IDynamicObject attacker, IDynamicObject target)
        {
            _attackAction(attacker, target);
        }

        public Func<IGameObject, bool> GetTargetPredicate(Position playerPosition)
        {
            return _getTargetPredicate(playerPosition);
        }
    }
}
