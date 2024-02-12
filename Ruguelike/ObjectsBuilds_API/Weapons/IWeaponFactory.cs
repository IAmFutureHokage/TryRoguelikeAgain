using Ruguelike.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruguelike.ObjectsBuilds_API.Weapons
{
    public interface IWeaponFactory
    {
        IWeapon CreateSword();
        IWeapon CreateBow();
    }
}
