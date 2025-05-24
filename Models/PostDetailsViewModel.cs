using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoticiasEnriquecidas.Models
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}