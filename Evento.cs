using System;
using System.IO;

public class Evento() {
    public string Nome { get; set; } = "";
    public float Valor { get; set; } = 0;
    public int IdadeMinima { get; set; } = 13;
    public int QntIngressos { get; set; } = 0;

    public bool IngressosDisponiveis(List<Usuario> usuarios) {
        if (QntIngressos <= usuarios.Count())
        {
            return false;
        }
        else { return true; }
    }

    public bool ChecarIdadeMininma(Usuario usuario) {
        if (usuario.Idade >= IdadeMinima) {
            return true;
        }
        else { return false; }
    }
}