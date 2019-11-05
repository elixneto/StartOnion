namespace StartOnion.Camada.Dominio.TestesDeUnidade.NullObjects
{
    class EntidadeNull : Entidade
    {
        public string CampoCustom => "Campo Custom";

        public EntidadeNull()
        {
            base.Validar(new ValidadorDeEntidadeNull());
        }
    }
}
