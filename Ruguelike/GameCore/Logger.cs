using Ruguelike.GameObjects;

namespace Ruguelike.GameCore
{
    public class Logger
    {
        public void LogAttack(IDynamicObject attacker, IDynamicObject target)
        {
            Console.WriteLine($"Logger: {attacker.Title} has attacked {target.Title}.");
        }
    }
}
