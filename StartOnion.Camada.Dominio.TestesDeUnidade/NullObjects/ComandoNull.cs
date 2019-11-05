namespace StartOnion.Camada.Dominio.TestesDeUnidade.NullObjects
{
    class ComandoNull : Comando<Cmd>
    {
    }

    class Cmd
    {
        public string Comando { get; set; }
    }
}
