using System;
using System.IO;

public class Usuario() {
    public int Evento { get; set; }
    public string Nome {get; set;} = "";
    public int Idade {get; set;} = 0;
    public string Email {get; set;} = "";

    public bool ChecarEmail() {
        if(Email.Contains("@hotmail.com") || Email.Contains("@gmail.com") || Email.Contains("@outlook.com"))
        {
            return true;
        }
        else { return false; }
    }

    public bool ChecarIdadeCadastro() {
        if (Idade >= 13) 
        { 
            return true; 
        }
        else { return false; }
    }
}