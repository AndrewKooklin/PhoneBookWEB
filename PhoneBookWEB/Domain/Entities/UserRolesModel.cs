using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookWEB.Domain.Entities
{
    public class UserRolesModel
    {
        public static string EMail { get; set; } = "";

        public static List<string> Roles { get; set; } = new List<string>{"Anonymus"};
    }
}
