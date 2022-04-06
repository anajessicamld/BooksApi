using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApi.Domain.Entities
{
    public abstract class BaseBook
    {
        public virtual int Id { get; set; }     // Obriga todos os modelos a possuírem um Id
    }

}
