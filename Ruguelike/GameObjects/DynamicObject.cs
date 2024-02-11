using Ruguelike.API;
using Ruguelike.CustomStructures;
using Ruguelike.GameObjects.Structures;
using Ruguelike.Weapons;

namespace Ruguelike.GameObjects
{
    public class DynamicObject (char sprite, Position position, bool passable, int hp, IWeapon weapon) : IGameObject, IDynamicObject
    {
        private BaseStats stats = new(sprite, position, passable);
        public int HP { get; set; } = hp;
        
        public IWeapon Weapon { get; } = weapon;

        public Guid Id => stats.Id;
        public char Sprite { get => stats.Sprite; set => stats.Sprite = value; }
        public Position Position { get => stats.Position; set => stats.Position = value; }
        public bool Passable { get => stats.Passable; set => stats.Passable = value; }
        public bool Alive { get => stats.Alive; set => stats.Alive = value; }

        public void Attack(IDynamicObject target)
        {
            if (!Alive) { return; }
            Weapon.Attack(this, target);
        }
        public void Move(Direction direction, Func<Position, bool> canMove)
        {
            if (!Alive) { return; }
            Position newPosition = Position.Move(direction);

            if (canMove(newPosition)) { Position = newPosition; }
        }
        public void TakeDamage(int damage)
        {
            if (!Alive) { return; }
            HP -= damage;
            if (HP < 0)
            {
                Alive = false;
                Sprite = '†';
            }
        }
        public IGameObject CloneWithNewPosition(Position newPosition)
        {
            return new DynamicObject(stats.Sprite, newPosition, stats.Passable, HP, Weapon);
        }
    }
}
