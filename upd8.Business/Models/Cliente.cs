using System;
using System.ComponentModel.DataAnnotations;

namespace upd8.Business.Models;

public class Cliente : Entity
{
    

    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Sexo { get; set; }
    public string Endereco { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }

}
