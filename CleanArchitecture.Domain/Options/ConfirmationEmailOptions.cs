using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Options;

public class ConfirmationEmailOptions : EmailOptions
{
    public string ConfirmEmailBaseLink { get; set; }
}
