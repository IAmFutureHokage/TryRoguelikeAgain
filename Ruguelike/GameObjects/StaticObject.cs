using Ruguelike.API;
using Ruguelike.CustomStructures;
using Ruguelike.GameObjects.Structures;
using Ruguelike.Weapons;

namespace Ruguelike.GameObjects
{
    public class StaticObject(char sprite, Position position, bool passable = false) : IGameObject
    {
        private BaseStats stats = new(sprite, position, passable);

        public Guid Id => stats.Id;
        public char Sprite { get => stats.Sprite; set => stats.Sprite = value; }
        public Position Position { get => stats.Position; set => stats.Position = value; }
        public bool Passable { get => stats.Passable; set => stats.Passable = value; }
        public bool Alive { get => stats.Alive; set => stats.Alive = value; }

        public IGameObject CloneWithNewPosition(Position newPosition)
        {
            return new StaticObject(stats.Sprite, newPosition, stats.Passable);
        }
    }
}
