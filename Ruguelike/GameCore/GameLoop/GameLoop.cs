using Ruguelike.GameCore.CollisionManager;
using Ruguelike.GameCore.GameController;
using Ruguelike.GameCore.GameInitializer;
using Ruguelike.GameCore.GameRenderer;
using Ruguelike.GameSceneRepository;

namespace Ruguelike.GameCore.GameLoop
{
    public class GameLoop(IGameConfig config, ICollisionManager collisionManager, IGameRender renderer, IGameController controller, IGameInitializer initializer) : IGameLoop
    {
        private readonly IGameConfig config = config;
        private readonly ICollisionManager collisionManager = collisionManager;
        private readonly IGameRender renderer = renderer;
        private readonly IGameController controller = controller;
        private readonly IGameInitializer initializer = initializer;

        public void Run()
        {
            while (!config.GameOver)
            {
                CheckFinished();
                renderer.Render();
                var key = Console.ReadKey(true).Key;

                controller.ProcessInput(key);
            }
            OnGameOver();
        }
        
        private void CheckFinished() 
        {
            if (collisionManager.CheckCollision(config.PlayerId, config.FinishId)){initializer.Init(); }
        }
        private static void OnGameOver()
        {
            Console.WriteLine("Игра завершена! Поставьте 5 звезд в убер, пожалуйста!");
        }
    }
}
