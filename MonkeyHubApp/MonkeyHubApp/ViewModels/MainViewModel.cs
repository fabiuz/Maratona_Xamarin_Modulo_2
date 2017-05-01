using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private string _SearchTerm;

        public string SearchTerm
        {
            get { return _SearchTerm; }
            set {
                if(SetProperty(ref _SearchTerm, value))
                {
                    SearchCommand.ChangeCanExecute();
                }
            }
        }
        
        public Command SearchCommand { get; } 

        public MainViewModel()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
        }

        async void ExecuteSearchCommand()
        {
            await Task.Delay(2000);

            bool resposta = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Vc pesquisou por tal coisa?{SearchTerm}", "Sim", "OK");

            if (resposta)
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Obrigado", "OK");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "De nada", "OK");
            }
        }

        bool CanExecuteSearchCommand()
        {
            return string.IsNullOrWhiteSpace(SearchTerm) == false;
        }
    }
}
