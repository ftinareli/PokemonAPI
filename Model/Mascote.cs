using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonAPI.Model
{
    internal class Mascote
    {
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public List<Abilities> abilities { get; set; }

        public enum Mascotes
        {
            charmander = 1,
            pikachu = 2,
            blastoise = 3
        }
    }
}
