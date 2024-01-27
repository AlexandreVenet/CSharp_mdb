using System;
using System.Collections.Generic;
//----------------------
// Installer le package NuGet selon la version de .NET
using System.Data.OleDb; 
 //----------------------
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_mdb
{
	internal class AppMDB
	{
		private string _nomFichier = "monFichier.mdb";
		private string _cheminFichier;



		public void Demarrer()
		{
			// Admettons que le fichier existe dans le dossier de la solution.
			// Propriétés > "Copier dans le répertoire de sortie" = Copier si plus récent.
			_cheminFichier = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _nomFichier);

			ExplorerMDB();
		}

		private void ExplorerMDB()
		{
			string provider = "Microsoft.ACE.OLEDB.12.0";  // Installer sur la machine : https://www.microsoft.com/en-us/download/details.aspx?id=54920
			string passe = "mot_de_passe";
			string chaineConnexion = @$"Provider={provider}; Data Source={_cheminFichier}; Persist Security Info=False;Jet OLEDB:Database Password={passe};";

			string chaineRequete = "SELECT col1, col2 FROM ma_table";

			using (OleDbConnection connexion = new(chaineConnexion))
			{
				using (OleDbCommand commande = new(chaineRequete, connexion))
				{
					connexion.Open();

					using (OleDbDataReader reader = commande.ExecuteReader())
					{
						while (reader.Read())
						{
							Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString());
						}
					}
				}
			}
		}
	}
}
