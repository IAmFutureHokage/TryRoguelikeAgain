using Ruguelike;
using Ruguelike.API;
using Ruguelike.CustomStructures;
using Ruguelike.EntityGenerators;
using Ruguelike.GameCore.CollisionManager;
using Ruguelike.GameCore.GameController;
using Ruguelike.GameCore.GameInitializer;
using Ruguelike.GameCore.GameLoop;
using Ruguelike.GameCore.GameRenderer;
using Ruguelike.GameObjects;
using Ruguelike.GameSceneRepository;
using Ruguelike.MazeGenerator;

class Program
{
    static void Main()
    {
        IGameConfig config = new GameConfig(50, 20);
        IGameSceneRepository gameScene = new GameSceneRepository();
        IPrototypeFactory factory = new PrototypeFactory();

        IGameInitializer initializer = new GameInitializer(config, gameScene, factory);
        initializer.Init();

        IGameRender gameRender = new GameRender(gameScene, config);
        ICollisionManager collisionManager = new CollisionManager(gameScene);
        IGameController gameController = new GameController(config, gameScene, collisionManager);
        IGameLoop gameLoop = new GameLoop(config, collisionManager, gameRender, gameController, initializer);

        gameLoop.Run();
    }
}