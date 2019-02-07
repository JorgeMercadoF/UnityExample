using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityExample.Contracts
{
    public interface IGame
    {
        string Name { get; }
        int CurrentPlayers { get; }
        int MinPlayers { get; }
        int MaxPlayers { get; }

        void addPlayer();
        void removePlayer();
        void play();
        string result();
    }
}


// Prueba GitHub