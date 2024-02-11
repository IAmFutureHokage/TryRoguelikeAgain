using Ruguelike.CustomStructures;

namespace Ruguelike.GameObjects
{
    public interface IGameObject
    {
        Guid Id { get; }
        char Sprite { get; }
        Position Position { get; }
        bool Passable { get; }
        bool Alive { get; }
        IGameObject CloneWithNewPosition(Position newPosition);
    }
}
