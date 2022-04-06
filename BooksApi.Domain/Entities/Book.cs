using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApi.Domain.Entities
{
    public class Book : BaseBook
    {
        
        //public int Id { get; set; }    - presente no BaseEntity
        public string Author { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        
    }
}
