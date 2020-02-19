using System;
using System.Collections.Generic;
namespace DojoDungeon
{
  class Program
  {
    public static void Main(string[] args)
    {

      System.Console.WriteLine("Hello! what is your name?");
      Hero player = new Hero(Console.ReadLine());
      System.Console.WriteLine($"Okay {player.name}, it's time to fight stuff.");
      System.Console.WriteLine("Press Enter...");
      Console.ReadLine();
      Console.Clear();
      System.Console.WriteLine("Oh No! Algorithms! let's beat 'em up.");
      System.Console.WriteLine();


      Dungeon DojoDungeon = new Dungeon(player, 5);
      
      DojoDungeon.AllMinions.Add
      (
            new Minion(300, "Dunder  Master Cody", 25,10,20)
      );
      DojoDungeon.Battle();
      Console.WriteLine("we are done");
      Console.ReadLine();
    }
  }


  public class Character
  {
    public int HP;
    public string name;
    public int Strength;
    public int Defense;
    public int Mana;

    public Boolean IsAlive;

  }
  public class Hero : Character
  {
      public int lastHitDamageDealt {get; set;} = 0;
    public Hero(string name)
    {
        this.name = name;
        this.Strength = 10;
        this.HP = 200;
        this.Defense = 10;
        this.Mana = 100;
        this.IsAlive = true;

    }


    public void Attack(Character target)
    {
        target.HP += (-3 * Strength) + (target.Defense);
        lastHitDamageDealt =  (-3 * Strength) + (target.Defense);
    }
    public void Critical(Character target)
    {
        target.HP += (-6 * Strength);
        System.Console.WriteLine("Lucky you a critical hit!");
         lastHitDamageDealt = (-6 * Strength);
    }

    public void MagicAttack(Character target)
    {
        if (Mana > 25)
        {
            target.HP += (-4 * Strength);
            Mana = Mana - 10;
            lastHitDamageDealt = (-4 * Strength);
        }
        else
        {
            System.Console.WriteLine("Not enough mana! Learn resource management!");
        }
    }
    public void heal()
    {
        if (Mana > 9)
        {
            this.HP += 50;
            Mana = Mana - 10;
        }
        else
        {
            System.Console.WriteLine("Not enough mana! Learn resource management!");
        }
    }

    public void MagicCrit(Character target)
    {
        if (Mana > 25)
        {
            target.HP += (-8 * Strength);
            Mana = Mana - 10;
            System.Console.WriteLine("You landed a critical! Lucky shot I guess");
        }
        else
        {
            System.Console.WriteLine("Not enough mana! Learn resource management!");
        }
    }



  }
  public class Boss : Character
  {
    public Boss(string name)
    {
        this.name = name;
        this.HP = 2000;
        this.Strength = 20;
        this.Defense = 20;
        this.Mana = 500;
    }
    public void Attack(Character target)
    {
      target.HP += (-2 * Strength) + (target.Defense * 1);
    }
    public void Critical(Character target)
    {
      target.HP += (-2 * Strength);
    }
    public void MagicAttack(Character target)
    {
        if (Mana > 100)
        {
            target.HP += (-4 * Strength);
            Mana = Mana - 50;

        }
    }
    public void Heal()
    {
        if (HP < 300)
        {
            HP += 200;
        }
    }
    public void FinalMove(Character target)
    {
        if (HP < 100)
        {
            target.HP += -5 * Strength;
        }
    }
  }
  class Minion : Character
  {
    public Random rando = new Random();

    // fill me in later with a bunch of names so we can randomly grab one
    List<string> MinionNames = new List<string>()
    {
        "SLL",
        "Sort",
        "AddToBack",
        "BubbleSort",
        "AddToFront",
        "Romans",
        "FizzBuzz",
        "Sigma",
        "Fibonacci",
        "OddArray",
        "ValidPalindrome"
    };
    public Minion()
    {
        this.HP = 100;
        this.name = MinionNames[rando.Next(0, MinionNames.Count - 1)];
        this.Strength = 10;
        this.Defense = 10;
        this.Mana = 0;
    }
    public Minion(int HP = 300 , string title = "Name" ,int strength = 10, int defense = 5, int Mana = 0)
    {
        this.HP = HP;
        this.name = title;
        this.Strength= strength;
        this.Defense=defense;
        this.Mana = Mana;

    }

    public int Attack(Character target)
    {
      target.HP += (-2 * Strength) + (target.Defense * 1);
      return (-2 * Strength) + (target.Defense * 1);
    }
  }

  class Dungeon
  {

    // public Boss TheBoss;
    public List<Minion> AllMinions = new List<Minion>();

    public Hero player;

    public Minion currentEnemy;
    

    public Dungeon(Hero player, int numOfMinions)
    {
        this.player = player;
        stockDungeonWithMinions(numOfMinions);
        currentEnemy = AllMinions[0];
    }
    //todo
    // public Dungeon(Hero player, Boss boss)
    // {
    //     this.player = player;
    //     currentEnemy = boss;

    // }
    public void KillMinion(Minion target)
    {
        Console.WriteLine($"{target.name} has been vanquished");
        AllMinions.Remove(target);
        if (AllMinions.Count > 0)
        {
            currentEnemy = AllMinions[0];
        }
        else
        {
            Console.WriteLine("theyre all dead!");
            Console.ReadLine();
            currentEnemy = null;
        }
    }
    //todo
    // public void killBoss(Boss target)
    // {
    //     Console.WriteLine($"{target.name} has been vanquished");
    //     AllBosses.Remove(target);
    // }
    public void addMinion()
    {
        AllMinions.Add(new Minion());
    }

    public void stockDungeonWithMinions(int howManyMinions)
    {
        for (var i = 0; i <= howManyMinions; i++)
        {
            AllMinions.Add(new Minion());
        }
    }

    public int countMinions()
    {
        return AllMinions.Count;
    }

    public void Battle()
    {
        while (player.IsAlive == true && AllMinions.Count > 0)
        {
            this.turn();

               if (player.HP <= 0) {
            Console.WriteLine("YOU HAVE BEEN DUNDERED");
            break;
        }
        // currentEnemy.;

        }
        
    }
    public void turn()
    {
        Random Chance = new Random();
        int Probabilty = Chance.Next(1,10);
        Console.WriteLine("------------------------------------------------");
        System.Console.WriteLine($"the algorithm '{currentEnemy.name}' has {currentEnemy.HP} HP remaining"); 
        System.Console.WriteLine($"You have {player.HP} HP remaining");
        System.Console.WriteLine($"You have {player.Mana} Mana remaining");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("What do you want to do?");
        Console.WriteLine("\ta - Attack");
        Console.WriteLine("\tw - Magic");
        Console.WriteLine("\ts - Run");
        Console.WriteLine("\td - Heal");
        Console.Write("Your option? ");
        switch (Console.ReadLine())
        {
            case "a":
            if ( Probabilty == 5) 
            {
                Console.Clear();
                player.Critical(currentEnemy);
            }
            else
            {
                Console.Clear();
                player.Attack(currentEnemy);
            }
            break;
            case "w":
            if (Probabilty == 8)
            {
                Console.Clear();
                player.MagicCrit(currentEnemy);
            }
            else
            {
                Console.Clear();
                player.MagicAttack(currentEnemy);
            }
            break;
            case "s":
            Console.Clear();
            Console.WriteLine("run");
            break;
            case "d":
            Console.Clear();
            player.heal();
            break;
        }
        if (currentEnemy.HP > 0) {
            var theyHitYouFor =  currentEnemy.Attack(player);
            Console.WriteLine($"{currentEnemy.name} hit you for {theyHitYouFor}");
        }
        if (currentEnemy.HP <= 0)
        {
            this.KillMinion(currentEnemy);
        }
     
    }
  }
}
