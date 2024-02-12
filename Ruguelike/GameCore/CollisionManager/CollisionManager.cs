using Ruguelike.CustomStructures;
using Ruguelike.GameSceneRepository;

namespace Ruguelike.GameCore.CollisionManager
{
    public class CollisionManager (IGameSceneRepository gameScene) : ICollisionManager
    {
        private readonly IGameSceneRepository gameScene = gameScene;

        public bool CanMove(Position position)
        {
            var objects = gameScene.GameObjects(obj => obj.Position.Equals(position));

            return !objects.Any(obj => !obj.Passable);
        }

        public bool CheckFinishReached(Guid playerId, Guid finishId)
        {
            Position player = gameScene.FindById(playerId)?.Position ?? throw new InvalidOperationException("Игрока нет на карте");
            Position finish = gameScene.FindById(finishId)?.Position ?? throw new InvalidOperationException("Финиша нет на карте");

            return player == finish;
        }
    }
}
