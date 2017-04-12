using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentPreparer.Models
{
    public class ManagementBlock
    {
        public ManagementBlock()
        {
            Individual = new Individual();
            Entity = new Entity();
        }

        public Individual Individual { get; set; }
        public Entity Entity { get; set; }
    }

    public class Individual
    {
        public string Position { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get {
                return string.Join(" ", LastName, FirstName, MiddleName);
            } }
        public string INN { get; set; }
        public string LeaderOf { get; set; }
        public string FounderOf { get; set; }
    }

    public class Entity
    {
        public string Name { get; set; }
        public string INN { get; set; }
        public string Address { get; set; }
    }
}
