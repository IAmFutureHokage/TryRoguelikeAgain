using Ruguelike.CustomStructures;

namespace Ruguelike.GameCore.CollisionManager
{
    public interface ICollisionManager
    {
        bool CanMove(Position position);
        bool CheckFinishReached(Guid playerId, Guid finishId);
    }
}
