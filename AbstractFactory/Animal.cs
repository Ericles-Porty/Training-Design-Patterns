// Abstract Factory pattern -- Real World example

using System;

namespace Abstract.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Abstract Factory Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create and run the African animal world

            ContinentFactory africa = new AfricaFactory();

            var world = new AnimalWorld(africa);

            world.RunFoodChain();


            // Create and run the American animal world

            ContinentFactory america = new AmericaFactory();

            world = new AnimalWorld(america);

            world.RunFoodChain();

            // Create and run the American animal world

            ContinentFactory asia = new AsiaFactory();

            world = new AnimalWorld(asia);

            world.RunFoodChain();

            // Wait for user input
            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    internal abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();

        public abstract Plants CreatePlants();
    }


    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    internal class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
        public override Plants CreatePlants()
        {
            return new GalhoSeco();
        }
    }


    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    internal class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
        public override Plants CreatePlants()
        {
            return new Mato();
        }
    }

    internal class AsiaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Camelo();
        }

        public override Carnivore CreateCarnivore()
        {
            return new Tigre();
        }
        public override Plants CreatePlants()
        {
            return new Bambu();
        }
    }

    internal abstract class Plants
    {
    }
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    internal abstract class Herbivore
    {
        public abstract void Eat(Plants p);
    }


    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    internal abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    internal class Bambu : Plants
    {
    }

    internal class Mato : Plants
    {
    }

    internal class GalhoSeco : Plants
    {
    }
    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    internal class Wildebeest : Herbivore
    {
        public override void Eat(Plants p)
        {
            Console.WriteLine(GetType().Name +
                              " eats " + p.GetType().Name);
        }
    }


    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    internal class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest

            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }


    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    internal class Bison : Herbivore
    {
        public override void Eat(Plants p)
        {
            Console.WriteLine(GetType().Name +
                              " eats " + p.GetType().Name);
        }
    }


    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    internal class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison

            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }

    internal class Tigre : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison

            Console.WriteLine(GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }
    internal class Camelo : Herbivore
    {
        public override void Eat(Plants p)
        {
            // Eat Bison

            Console.WriteLine(GetType().Name +
                              " eats " + p.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Client' class
    /// </summary>
    internal class AnimalWorld
    {
        private readonly Carnivore _carnivore;
        private readonly Herbivore _herbivore;
        private readonly Plants _plants;


        // Constructor

        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();

            _herbivore = factory.CreateHerbivore();

            _plants = factory.CreatePlants();
        }


        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
            _herbivore.Eat(_plants);
        }
    }
}