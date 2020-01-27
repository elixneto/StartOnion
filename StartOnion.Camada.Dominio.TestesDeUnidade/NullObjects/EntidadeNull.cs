namespace StartOnion.Camada.Dominio.TestesDeUnidade.NullObjects
{
    class EntidadeNull : Entidade
    {
        public string CampoCustom => "Campo Custom";

        public EntidadeNull() : base(new ValidadorDeEntidadeNull())
        {
            base.Validar();
        }
    }
}
