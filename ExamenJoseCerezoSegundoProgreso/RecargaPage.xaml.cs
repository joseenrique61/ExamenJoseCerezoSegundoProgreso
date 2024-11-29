using ExamenJoseCerezoSegundoProgreso.Models;
using System.Text.Json;

namespace ExamenJoseCerezoSegundoProgreso;

public partial class RecargaPage : ContentPage
{
	public RecargaPage()
	{
		InitializeComponent();

		LoadModel();
	}

	private void LoadModel()
	{
		Recarga recarga = new();
		string path = Path.Combine(FileSystem.AppDataDirectory, "JoseCerezo.txt");
		if (File.Exists(path)) {
			string content = File.ReadAllText(path);
			recarga = JsonSerializer.Deserialize<Recarga>(content)!;
		}
		BindingContext = recarga;
	}

	private void jcerezo_buttonRecarga_Clicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(jcerezo_editorNombre.Text) || string.IsNullOrEmpty(jcerezo_editorTelefono.Text))
		{
			//codigo de alerta
			return;
		}

		Recarga recarga = new()
		{
			Nombre = jcerezo_editorNombre.Text,
			Numero = jcerezo_editorTelefono.Text
		};

		string path = Path.Combine(FileSystem.AppDataDirectory, "JoseCerezo.txt");
		using FileStream file = new(path, FileMode.Create);
		JsonSerializer.Serialize(file, recarga);

		BindingContext = recarga;

		//codigo de confirmacion
	}
}