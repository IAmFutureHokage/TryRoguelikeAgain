using Ruguelike.GameSceneRepository;

namespace Ruguelike.GameObjects
{
    public interface IAutoObject : IGameObject
    {
        public IAutoObject AddStageAction(Func<IGameSceneRepository, IAutoObject, Func<IGameObject, bool>, int> action, Func<IGameObject, bool> condition);
        public void Update(IGameSceneRepository gameScene);
    }
}
