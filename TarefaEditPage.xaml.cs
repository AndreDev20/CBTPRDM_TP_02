/*
Nomes: André Luiz Nascimento de Andrade e João do Valle Seixas Paula

*/
namespace TarefasApp;

public partial class TarefaEditPage : ContentPage
{
    private readonly Tarefa original;
    private readonly Tarefa editModel;

    public TarefaEditPage(Tarefa originalTarefa)
    {
        InitializeComponent();

        original = originalTarefa ?? throw new ArgumentNullException(nameof(originalTarefa));

        // Trabalha com uma cópia para permitir cancelar sem afetar o original
        editModel = new Tarefa
        {
            Titulo = original.Titulo,
            Descricao = original.Descricao,
            DataCriacao = original.DataCriacao,
            Prioridade = original.Prioridade
        };

        this.BindingContext = editModel;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        // Aplica alterações ao objeto original (isso notificará a UI porque Tarefa implementa INotifyPropertyChanged)
        original.Titulo = editModel.Titulo;
        original.Descricao = editModel.Descricao;
        original.DataCriacao = editModel.DataCriacao;
        original.Prioridade = editModel.Prioridade;

        await Navigation.PopModalAsync();
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        // Descarta alterações
        await Navigation.PopModalAsync();
    }
}
