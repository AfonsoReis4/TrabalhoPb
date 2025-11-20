using Microsoft.AspNetCore.Identity;

namespace GestaoLoja.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        //nif
        public string? NIF { get; set; }
        //rua

        public string? Rua { get; set; }
        //localidade1
        public string? Localidade1 { get; set; }
        //pais
        public string? Pais { get; set; }
        //Fotografia
        public byte[]? Fotografia { get; set; }
    }

}
