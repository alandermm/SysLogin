using System;
using System.IO;
using System.Text;

namespace SistemaLogin
{
    public class Usuario
    {
        public delegate void EventoLogar();
        public event EventoLogar Logar;
        
        public delegate void EventoDeslogar();
        public event EventoDeslogar Deslogar;
        public Usuario(string login, string senha) 
        {
            this.login = login;
            this.senha = senha;
               
        }

         public string login {get; set;}
        public string senha {get; set;}

        public void Login(){
            this.Logar();
        }

        public void Logout(){
            this.Deslogar();
        }

        public bool Cadastrar(Usuario usuario){
            bool efetuado = false;
            StreamWriter arquivo = null;
            try{
                arquivo = new StreamWriter("cadUsuario.txt", true);
                arquivo.WriteLine(this.login + ";" + this.senha);
                efetuado = true;
            } catch (Exception ex) {
                throw new Exception("Erro ao tentar gravar o arquivo. " + ex.Message);
            } finally {
                arquivo.Close();
            }
            return efetuado;
        }

        public string Pesquisar(string login){
            string resultado = "Usuário não encontrado";
            StreamReader ler = null;
            try{
                ler = new StreamReader("cadUsuario.txt", Encoding.Default);
                string linha = "";
                while((linha=ler.ReadLine()) != null){
                    string[] credencial = linha.Split(';');
                    if(credencial[0] == login){
                        resultado = linha;
                        break;
                    }
                }
            } catch (Exception ex) {
                resultado = "Erro ao tentar ler o arquivo. " + ex.Message;
            } finally {
                ler.Close();
            }
            return resultado;
        }
    }
}