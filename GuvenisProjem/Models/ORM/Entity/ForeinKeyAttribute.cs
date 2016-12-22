using System;

namespace GuvenisProjem.Models.ORM.Entity
{
    internal class ForeinKeyAttribute : Attribute
    {
        private string v;

        public ForeinKeyAttribute(string v)
        {
            this.v = v;
        }
    }
}