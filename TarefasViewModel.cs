/*
Nomes: André Luiz Nascimento de Andrade e João do Valle Seixas Paula

*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TarefasApp;

namespace ListViewDemos.ViewModels
{
    public class TarefasViewModel : INotifyPropertyChanged
    {
        readonly IList<Tarefa> source;
        Tarefa selectedTarefa;

        public ObservableCollection<Tarefa> Tarefas { get; private set; }

        public Tarefa SelectedTarefa
        {
            get => selectedTarefa;
            set
            {
                if (selectedTarefa != value)
                {
                    selectedTarefa = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand DeleteCommand => new Command<Tarefa>(RemoveTarefa);

        public TarefasViewModel()
        {
            source = new List<Tarefa>();
            CreateTarefaCollection();

            SelectedTarefa = Tarefas.FirstOrDefault();
            OnPropertyChanged("SelectedTarefa");
        }

        void CreateTarefaCollection()
        {
            source.Add(new Tarefa
            {
                Titulo = "Fazer mercado",
                Descricao = "Comprar arroz, feijão e ovo",
                DataCriacao = DateTime.Now.AddDays(-2),
                Prioridade = "Média"
            });

            source.Add(new Tarefa
            {
                Titulo = "Fazer TP02",
                Descricao = "Realizar a atividade.",
                DataCriacao = DateTime.Now.AddDays(-1),
                Prioridade = "Média"
            });

            source.Add(new Tarefa
            {
                Titulo = "Estudar MAUI",
                Descricao = "Rever navegação e bindings",
                DataCriacao = DateTime.Now,
                Prioridade = "Baixa"
            });

            Tarefas = new ObservableCollection<Tarefa>(source);
        }

        void RemoveTarefa(Tarefa tarefa)
        {
            if (Tarefas.Contains(tarefa))
            {
                Tarefas.Remove(tarefa);
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}