using System.Threading.Tasks;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;
public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	} 
    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Categoria = picker_categoria.SelectedItem?.ToString()?? "Outros",
                Preco = Convert.ToDouble(txt_preco.Text)
            };
            await App.Db.Insert(p); //inserindo novos dados
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK"); //mensagem que salva os itens.
            await Navigation.PopAsync(); //voltando para a página inicial da lista dos produtos.

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}

