using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DebtForgivenessRegistration.Features.Customers.Models;
#region
/*
 * https://stackoverflow.com/questions/7067874/regular-expression-for-ssn
 */
#endregion
[Index(nameof(SocialSecurityNumber), IsUnique = true)]
public sealed class Customer: IEquatable<Customer>
{
    [Key]
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string FirstName { get; set; } = default!;
    [Required, StringLength(100)]
    public string MiddleName { get; set; } = default!;
    [Required, StringLength(100)]
    public string LastName { get; set; } = default!;
    [Required, StringLength(100),RegularExpression(@"^\d{3}-\d{2}-\d{4}$", ErrorMessage = "Invalid Social Security Number")]
    public string SocialSecurityNumber { get; set; } = default!;
    [Required]
    public DateTime RegistrationDate { get; set; } = DateTime.Now;

    public bool Equals(Customer? other)
    {
        return other is null ? false: SocialSecurityNumber.Equals(other.SocialSecurityNumber);
    }

    public override int GetHashCode()
    {
        return SocialSecurityNumber.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Customer);
    }
}

