using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterndesignexercises
{
    public interface IPrototype
    {
        GameCharacter Clone();
    }
    public class GameCharacter : IPrototype
    {
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public List<string> Skills { get; set; }

        public GameCharacter()
        {
            Skills = new List<string>();
        }

       
        public GameCharacter Clone()
        {
            return new GameCharacter
            {
                Health = this.Health,
                Attack = this.Attack,
                Defense = this.Defense,
                Skills = new List<string>(this.Skills) 
            };
        }
    }
    public class WarriorPrototype
    {
        public GameCharacter WarriorBase { get; private set; }

        public WarriorPrototype()
        {
            WarriorBase = new GameCharacter
            {
                Health = 100,
                Attack = 20,
                Defense = 15,
                Skills = new List<string> { "Slash", "Shield Block" }
            };
        }
    }
    internal class gamechanger_ex_3_
    {
        public static void Main(string[] args)
        {
            WarriorPrototype prototype = new WarriorPrototype();

           
            GameCharacter warrior1 = prototype.WarriorBase.Clone();
            GameCharacter warrior2 = prototype.WarriorBase.Clone();

           
            warrior2.Health = 120;
            warrior2.Skills.Add("Rage Mode");

            Console.WriteLine("Warrior 1 Skills: " + string.Join(", ", warrior1.Skills));
            Console.WriteLine("Warrior 2 Skills: " + string.Join(", ", warrior2.Skills));
        }
    }
}
