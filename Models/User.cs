using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TaskDB.MVC
{
    public class User : IdentityUser
    {
        public List<TaskModel> Tasks { get; set; }
    }

}