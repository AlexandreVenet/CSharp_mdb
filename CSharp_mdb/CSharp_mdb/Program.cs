namespace CSharp_mdb
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;


			new AppMDB().Demarrer();


			Console.WriteLine("Fin du programme");
			Console.Read();
		}
	}
}
