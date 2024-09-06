namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            try
            {
                if (hospedes.Count() <= this.Suite.Capacidade)
                {
                    Hospedes = hospedes;
                }
                else
                {
                    throw new Exception("A suíte escolhida não possuiu capacidade para a quantidade de hóspedes informada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes != null ? this.Hospedes.Count() : 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = this.DiasReservados * this.Suite.ValorDiaria;

            // Regra: Caso os dias reservados forem maior ou igual a 10, conceder um desconto de 10%
            if (this.DiasReservados >= 10)
            {
                valor = valor - (valor * 0.10m);;
            }

            return valor;
        }
    }
}