using Ruguelike.CustomStructures;
using Ruguelike.GameObjects.Structures;
using Ruguelike.GameSceneRepository;

namespace Ruguelike.GameObjects
{
    public class AutoObject(char sprite, string title, Position position, bool passable = false) : IGameObject, IAutoObject
    {
        private BaseStats stats = new(sprite, title, position, passable);

        public Guid Id => stats.Id;
        public string Title => stats.Title;
        public char Sprite { get => stats.Sprite; set => stats.Sprite = value; }
        public Position Position { get => stats.Position; set => stats.Position = value; }
        public bool Passable { get => stats.Passable; set => stats.Passable = value; }
        public bool Alive { get => stats.Alive; set => stats.Alive = value; }

        private readonly List<(Func<IGameSceneRepository, IAutoObject, Func<IGameObject, bool>, int> Action, Func<IGameObject, bool> Condition)> stageActions = [];
        private int currentStage = 0;

        public IAutoObject AddStageAction(Func<IGameSceneRepository, IAutoObject, Func<IGameObject, bool>, int> action, Func<IGameObject, bool> condition)
        {
            stageActions.Add((action, condition));
            return this;
        }

        public void Update(IGameSceneRepository gameScene)
        {
            if (currentStage < stageActions.Count)
            {
                var (action, condition) = stageActions[currentStage];
                currentStage = action(gameScene, this, condition);
            }
        }

        public IGameObject CloneWithNewPosition(Position newPosition)
        {
            return new StaticObject(stats.Sprite, stats.Title, newPosition, stats.Passable);
        }
    }
}
