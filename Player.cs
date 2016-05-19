using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolePokeMon
{
    public class Player
    {
        string _name;
        IPokemon _activePokemon;
        IPokemon[] battleParty = new IPokemon[6];
        IPokemon[] someonesPC = new IPokemon[999];
        List<IPokemon> party = new List<IPokemon>();



        public Player()
        {

        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public IPokemon ActivePokemon
        {
            get { return _activePokemon; }
            set { _activePokemon = value; }
        }



        public IPokemon[] BattleParty
        {
            get { return battleParty; }
            set { battleParty = value; }
        }



        public IPokemon[] SomeonesPC
        {
            get { return someonesPC; }
            set { someonesPC = value; }
        }



        public List<IPokemon> Party
        {
            get { return party; }
            set { party = value; }
        }


        public override string ToString()
        {
            return Name;
        }
    }
}
