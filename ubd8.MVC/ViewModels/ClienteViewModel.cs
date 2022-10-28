using System.ComponentModel.DataAnnotations;

namespace upd8.MVC.ViewModels;

public class ClienteViewModel
{
    [Key]
    public Guid Id { get; set; }
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public string Endereco { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }
}
