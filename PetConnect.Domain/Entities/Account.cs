using PetConnect.Domain.Common;
using PetConnect.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetConnect.Domain.Entities;
public class Account : Entity
{

    public string Email { get; set; }

    public PhoneNumber PhoneNumber{ get; set; }

    public string PasswordHash { get; set; }

}
