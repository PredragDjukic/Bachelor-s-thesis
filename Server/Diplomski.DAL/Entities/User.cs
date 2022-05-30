using System;
using System.Collections.Generic;

namespace Diplomski.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Bundle = new HashSet<Bundle>();
            SessionExerciser = new HashSet<Session>();
            SessionTrainer = new HashSet<Session>();
        }

        public int Id { get; set; }
        public int UserType { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneNumberVerified { get; set; }
        public string SecretCode { get; set; } = null!;
        public DateTime SecretCodeExpiry { get; set; }
        public bool AreTermsAndServicesAccepted { get; set; }
        public bool IsPrivacyPolicyAccepted { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CustomerId { get; set; }

        public virtual ICollection<Bundle> Bundle { get; set; }
        public virtual ICollection<Session> SessionExerciser { get; set; }
        public virtual ICollection<Session> SessionTrainer { get; set; }
    }
}
