using System;
using System.Collections.Generic;

namespace AssemblyExample
{
    public class DomainEntity : IDomainEntity
    {
        //Fields
        //Properties
        //Fields
        //Events

        private readonly List<string> list = new List<string>();

        public void SaveChange()
        {
            list.Add(Guid.NewGuid().ToString());
        }
    }
}