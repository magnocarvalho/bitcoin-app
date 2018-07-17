using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinApp.Model
{
    public abstract class BaseEntity
    {
        [PrimaryKey]
        int Id { get; set; }

    }
}
