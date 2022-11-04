// Memento pattern -- Real World example

using System;

namespace Memento.RealWorld
{
    /// <summary>
    /// MainApp startup class for Real-World
    /// Memento Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            var s = new SalesProspect();

            s.Name = "Noel van Halen";

            s.Phone = "(412) 256-0990";

            s.Money = 2500.0;
            s.Budget = 25000.0;


            // Store internal state

            var m = new ProspectMemory();

            s.SaveMemento(m.Memento);
            

            // Continue changing originator

            s.Name = "Leo Welch";

            s.Phone = "(310) 209-7111";

            s.Money = 1000.0;
            s.Budget = 1000000.0;


            // Restore saved state

            s.Undo(m.Memento);
            s.Undo(m.Memento);

            s.Redo(m.Memento);



            // Wait for user

            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'Originator' class
    /// </summary>
    internal class SalesProspect
    {
        private double _budget;
        private string _name;
        private double _money;
        private string _phone;


        // Gets or sets name

        public string Name
        {
            get { return _name; }

            set
            {
                _name = value;

                Console.WriteLine("Name:  " + _name);
            }
        }


        // Gets or sets phone

        public string Phone
        {
            get { return _phone; }

            set
            {
                _phone = value;

                Console.WriteLine("Phone: " + _phone);
            }
        }


        // Gets or sets budget

        public double Budget
        {
            get { return _budget; }

            set
            {
                _budget = value;

                Console.WriteLine("Budget: " + _budget);
            }
        }

        public double Money
        {
            get { return _money; }

            set
            {
                _budget = value;

                Console.WriteLine("Money: " + _money);
            }
        }

        // Stores memento

        public Memento SaveMemento(Memento atual)
        {
            Console.WriteLine("\nSaving state --\n");

            var next = new Memento(_name, _phone, _budget, _money);
            atual.NextMemento = next;
            next.PreviousMemento = atual;

            return next;
        }

        public Memento Undo(Memento atual)
        {
            return atual.PreviousMemento;
        }


        public Memento Redo(Memento atual)
        {
            return atual.NextMemento;
        }
        // Restores memento

        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");

            Name = memento.Name;

            Phone = memento.Phone;

            Budget = memento.Budget;

            Money = memento.Money;
        }
    }


    /// <summary>
    /// The 'Memento' class
    /// </summary>
    internal class Memento
    {
        // Constructor

        public Memento(string name, string phone, double budget, double money)
        {
            Name = name;

            Phone = phone;

            Budget = budget;

            Money = money;
        }


        // Gets or sets name

        public string Name { get; set; }


        // Gets or set phone

        public string Phone { get; set; }
        public double Money { get; set; }


        // Gets or sets budget

        public double Budget { get; set; }

        public Memento NextMemento { get; set; }

        public Memento PreviousMemento { get; set; }

    }


    /// <summary>
    /// The 'Caretaker' class
    /// </summary>
    internal class ProspectMemory
    {
        // Property

        public Memento Memento { set; get; }
    }
}