<<<<<<< HEAD
﻿namespace MyApi.Models
=======
﻿namespace GroceryApi.Models
>>>>>>> 0ef7ab7f4ef1003900307c2bd54c6c0e7e18ca62
{
    public class User
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public string LoginName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
=======
        public string UserName { get; set; }

        public string Password { get; set; }

        public List<Grocery> Groceries { get; set; } = new List<Grocery>();
    }
}
>>>>>>> 0ef7ab7f4ef1003900307c2bd54c6c0e7e18ca62
