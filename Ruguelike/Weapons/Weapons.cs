using Ruguelike.CustomStructures;
using Ruguelike.GameObjects;

namespace Ruguelike.Weapons
{
    public class Sword : IWeapon
    {
        private readonly int Damage = 20;
        public void Attack(IDynamicObject attacker, IDynamicObject target)
        {
            target.TakeDamage(Damage);
           Console.WriteLine($"{attacker.Title} атаковал {target.Title}({target.HP}) с помощью меча. ");
        }
        public Func<IGameObject, bool> GetTargetPredicate(Position playerPosition)
        {
            return gameObject =>
            {
                var isNearby = Math.Abs(gameObject.Position.X - playerPosition.X) <= 1 && Math.Abs(gameObject.Position.Y - playerPosition.Y) <= 1;
                var isNotOnPlayerPosition = gameObject.Position.X != playerPosition.X || gameObject.Position.Y != playerPosition.Y;
                var isAlive = gameObject is IDynamicObject dynamicObject && dynamicObject.Alive;
                
                return isNearby && isNotOnPlayerPosition && isAlive;
            };
        }

    }

    public class Bow : IWeapon
    {
        public void Attack(IDynamicObject attacker, IDynamicObject target)
        {
            Console.WriteLine($"{attacker.Id} атакует {target.Id} с помощью лука.");
        }

        public Func<IGameObject, bool> GetTargetPredicate(Position playerPosition)
        {
            return gameObject =>
            {
                if (gameObject.Position == playerPosition || gameObject is not IDynamicObject dynamicObject)
                    return false;

                if (!dynamicObject.Alive)
                    return false;

                bool isOnSameLine = gameObject.Position.X == playerPosition.X || gameObject.Position.Y == playerPosition.Y;
                bool isWithinDistance = Math.Abs(gameObject.Position.X - playerPosition.X) <= 5 || Math.Abs(gameObject.Position.Y - playerPosition.Y) <= 5;

                return isOnSameLine && isWithinDistance;
            };
        }

    }
}
