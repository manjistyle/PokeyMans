using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsolePokeMon
{
    public enum Status
    {
        NORMAL,
        BURN,
        PARALYZE,
        FREEZE,
        POISON,
        BAD_POISON,
        CONFUSION,
        CURSE,
        ENCORE,
        FLINCH,
        INFATUATION,
        NIGHTMARE,
        SEEDED,
        PART_TRAPPED,
        LEVITATE,
        TORMENT,
        CHARGING,
        RECHARGING,
        PROTECTION,
        DEFENSE_CURL,
        WITHDRAWL,
        AIMING,
        MINIMIZE,
    }


    public enum Genus
    {
        NORMAL,
        FIRE,
        FIGHTING,
        WATER,
        FLYING,
        GRASS,
        POISON,
        ELECTRIC,
        GROUND,
        PSYCHIC,
        ROCK,
        ICE,
        BUG,
        DRAGON,
        GHOST,
        DARK,
        STEEL,
        FAE,
        MISSINGNO
    }



    public interface IPokemon
    {

        int MaxHP
        {
            get;
            set;
        }

        
        int GainXP(int xpGain);

        void TakeDamage(int damage);
    }


    public class Pokemon : IPokemon
    {
        string _name;
        int _maxHP;
        int _currentHP;
        int _currentXP;
        int _maxXPLVL;
        Attack[] attack = new Attack[4];



        public Pokemon()
        {

        }

        void TakeDamage(int damage)
        {
            CurrentHP -= damage;
        }


        public int CurrentHP
        {
            get { return _currentHP; }
            set { _currentHP = value; }
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }



        public Attack[] Attack
        {
            get { return attack; }
            set { attack = value; }
        }




        public int GainXP(int xpGain)
        {
            return xpGain;
        }



        public override string ToString()
        {
            return Name;
        }
    }
    


    public class Bulbasaur : IPokemon
    {
        string _name;
        int _maxHP;


        public Bulbasaur()
        {
            Name = "Bulbasaur";
            MaxHP = 50;
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }



        public int GainXP(int xpGain)
        {
            return xpGain;
        }


        public override string ToString()
        {
                return Name;
        }



    }


    public class Charmander : IPokemon
    {
        string _name;
        int _maxHP;


        public Charmander()
        {
            Name = "Charmander";
            MaxHP = 50;
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }



        public int GainXP(int xpGain)
        {
            return xpGain;
        }



        public override string ToString()
        {
            return Name;
        }
    }


    public class Squirtle : IPokemon
    {
        string _name;
        int _maxHP;


        public Squirtle()
        {
            Name = "Squirtle";
            MaxHP = 50;
        }



        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        public int MaxHP
        {
            get { return _maxHP; }
            set { _maxHP = value; }
        }



        public int GainXP(int xpGain)
        {
            return xpGain;
        }



        public override string ToString()
        {
            return Name;
        }
    }
}
