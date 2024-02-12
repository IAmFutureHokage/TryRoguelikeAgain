using Ruguelike.CustomStructures;
using Ruguelike.GameObjects;
using Ruguelike.Weapons;

namespace Ruguelike.API
{
    public class PrototypeFactory : IPrototypeFactory
    {
        private readonly Dictionary<string, IGameObject> prototypes = [];

        public PrototypeFactory()
        {
            InitPrototypes();
        }

        private void InitPrototypes()
        {
            prototypes["Wall"] = new StaticObject('#', "Wall",new Position(0, 0), false);
            prototypes["Finish"] = new StaticObject('F', "Finish", new Position(0, 0), true);

            prototypes["Player"] = new DynamicObject('P', "Player", new Position(0, 0), true, 100, new Sword());
            prototypes["Zombie"] = new DynamicObject('Z', "Zombie", new Position(0, 0), true, 100, new Sword());
            prototypes["Archer"] = new DynamicObject('A', "Archer", new Position(0, 0), true, 50, new Bow());
        }

        public IGameObject Create(string prototypeKey, Position position)
        {
            if (prototypes.TryGetValue(prototypeKey, out IGameObject? value))
            {
                return value.CloneWithNewPosition(position);
            }
            else
            {
                throw new ArgumentException($"Нет такого прототипа '{prototypeKey}'");
            }
        }
    }
}
