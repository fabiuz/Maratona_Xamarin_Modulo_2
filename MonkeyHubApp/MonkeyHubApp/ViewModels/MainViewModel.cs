using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set {
                _descricao = value;
                SetProperty(ref _descricao, value);
            }
        }

        private int _idade;

        public int Idade
        {
            get { return _idade; }
            set { _idade = value; SetProperty(ref _idade, value); }
        }


        public MainViewModel()
        {
            Descricao = "Olá, mundo, eu estou aqui";

            Task.Delay(1000).ContinueWith( t =>
            {
                Descricao = "O texto alterou.";

                for (int i = 0; i <= 10; i++)
                {
                    Task.Delay(1000);
                    Descricao = $"Meu texto mudou {i}";
                }
                
            });
        }

        
    }
}
