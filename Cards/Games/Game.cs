using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Games
{
    public abstract class Game
    {
        public string Name { get; protected set; }

        public abstract void Play();
    }
}
