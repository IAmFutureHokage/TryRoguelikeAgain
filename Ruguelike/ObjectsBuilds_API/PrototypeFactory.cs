using Ruguelike.CustomStructures;
using Ruguelike.GameObjects;
using Ruguelike.ObjectsBuilds_API.Weapons;

namespace Ruguelike.API
{
    public class PrototypeFactory : IPrototypeFactory
    {
        private readonly IWeaponFactory weaponFactory;
        private readonly Dictionary<string, IGameObject> prototypes = [];

        public PrototypeFactory(IWeaponFactory weaponFactory)
        {
            this.weaponFactory = weaponFactory;
            InitPrototypes();
        }

        private void InitPrototypes()
        {
            prototypes["Wall"] = new StaticObject('#', "Wall",new Position(0, 0), false);
            prototypes["Finish"] = new StaticObject('F', "Finish", new Position(0, 0), true);

            prototypes["Player"] = new DynamicObject('P', "Player", new Position(0, 0), true, 100, weaponFactory.CreateBow());
            prototypes["Zombie"] = new DynamicObject('Z', "Zombie", new Position(0, 0), true, 100, weaponFactory.CreateSword());
            prototypes["Archer"] = new DynamicObject('A', "Archer", new Position(0, 0), true, 50, weaponFactory.CreateBow());
        }

        public IGameObject Create(string prototypeKey, Position position)
        {
            if (!prototypes.TryGetValue(prototypeKey, out IGameObject? value))
            {
                throw new ArgumentException($"Нет такого прототипа '{prototypeKey}'");
            }
            return value.CloneWithNewPosition(position);
        }
    }
}
