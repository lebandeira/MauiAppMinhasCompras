namespace MauiAppMinhasCompras.Views;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls.PlatformConfiguration;

public partial class RelatorioCategoria : ContentPage
{
    public RelatorioCategoria()
    {
        InitializeComponent();
        CarregarRelatorio();
    }

    private async void CarregarRelatorio()
    {
        var produtos = await App.Db.GetAll();
        var relatorio = produtos
                        .GroupBy(p => p.Categoria)
                        .Select(g => new { Categoria = g.Key, Total = g.Sum(p => p.Total) })
                        .ToList();

        lst_relatorio.ItemsSource = relatorio;
    }
    
}