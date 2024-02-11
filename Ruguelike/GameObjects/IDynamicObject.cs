using Ruguelike.CustomStructures;
using Ruguelike.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruguelike.GameObjects
{
    public interface IDynamicObject : IGameObject
    {
        void Move(Direction direction, Func<Position, bool> canMove);
        public void Attack(IDynamicObject target);
        public IWeapon Weapon { get; }
        public void TakeDamage(int damage);
    }
}
