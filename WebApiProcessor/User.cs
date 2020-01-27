using System.Collections.Generic;

namespace WebApiProcessor
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public Address Address { get; set; } = new Address();
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; } = new Company();
        public List<ToDo> ToDos { get; set; } = new List<ToDo>();
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
