using System;
using System.Security.Cryptography;
using System.Text;

namespace SistemaLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            int opt;
            do
            {
                Console.WriteLine(
                    "Escolha uma opção:" +
                    "1 - Cadastrar" +
                    "2 - Logar" +
                    "3 - Logout" +
                    "9 - Sair"
                    );
                Console.Write("Opção: ");    
                opt = Int16.Parse(Console.ReadLine());

                switch(opt)
                {
                    case 1:
                    {

                        Usuario usuario = new Usuario();
                        break;
                    }
                    case 2:
                    {
                        Usuario usuario = new Usuario("Jorge", "1122334455");
                        usuario.Logar += new Usuario.EventoLogar();
                        usuario.Login();
                        break;
                    }
                    case 3:
                    {
                        Usuario usuario = new Usuario("Jorge", "1122334455");
                        usuario.Deslogar += new Usuario.EventoDeslogar();
                        usuario.Logout();
                        break;
                    }
                    case 9:
                    {
                        Environment.Exit(0);
                        break;
                    }
                }
            } while(opt != 9);
            //Console.WriteLine(encripSenha("123"));
        }

        public string[] PedirDadosUsuario(){
            string[] credencial = new string[2];
            Console.Write("Usuário: ");
            credencial[0] = Console.ReadLine();
            Console.Write("Senha: ");
            credencial[1] = Console.ReadLine();
            return credencial;
        }

        static string encripSenha(string senha){
            byte[] senhaOriginal;
            byte[] senhaModificada;
            //MD5 md5;
            senhaOriginal = Encoding.Default.GetBytes(senha);
            //md5 = MD5.Create();
            //senhaModificada = md5.ComputeHash(senhaOriginal);
            SHA512 sha512;
            sha512 = SHA512.Create();
            //senhaModificada = sha512.ComputeHash(senhaModificada);
            senhaModificada = sha512.ComputeHash(senhaOriginal);
            return Convert.ToBase64String(senhaModificada);
        }



    }
}
