using PetConnect.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Domain.Entities;
public class Account
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public PhoneNumber PhoneNumber{ get; set; }

    public string PasswordHash { get; set; }

}
