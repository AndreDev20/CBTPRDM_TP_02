/*
Nomes: André Luiz Nascimento de Andrade e João do Valle Seixas Paula

*/
using Microsoft.Extensions.DependencyInjection;

namespace TarefasApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
