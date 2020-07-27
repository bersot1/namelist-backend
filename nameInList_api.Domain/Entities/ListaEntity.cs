using System;
using System.Collections.Generic;
using System.Text;

namespace nameInList_api.Domain.Entities
{
    public class ListaEntity : Entity
    {
        public ListaEntity(string name, DateTime start, string description, string codigo, string password, Guid criatorId)
        {
            Name = name;
            Start = start;
            Description = description;
            Codigo = codigo;
            Password = password;
            CriatorId = criatorId;
        }

        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Description { get; set; }
        public string Codigo { get; set; }
        public string Password { get; set; }
        public Guid CriatorId { get; set; }
        public ICollection<UserListaEntity> UserLists { get; set; }

        //Guid.NewGuid().ToString().Substring(0, 7);


    }
}
