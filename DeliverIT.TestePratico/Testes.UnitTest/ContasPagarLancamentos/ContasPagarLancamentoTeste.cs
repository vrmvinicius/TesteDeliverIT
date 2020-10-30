using Dominio.Principal.Entidades;
using Dominio.Principal.Interfaces.Servicos;
using Dominio.Servicos.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Testes.UnitTest.ContasPagarLancamentos
{
    public class ContasPagarLancamentoTeste
    {
        [Fact]
        public void TodosOsCamposSaoObrigatorioNoLancamento()
        {
            var cp = new ContasPagar(null, null, null, 0);
            Assert.False(cp.Validar().IsValid);
            cp = new ContasPagar("Teste", null, null, 0);
            Assert.False(cp.Validar().IsValid);
            cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), null, 0);
            Assert.False(cp.Validar().IsValid);
            cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), new DateTime(2020, 10, 1), 0);
            Assert.False(cp.Validar().IsValid);
            cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), new DateTime(2020, 10, 1), 100);
            Assert.True(cp.Validar().IsValid);
        }

        [Fact]
        public void PagamentoAntecipadoRetornaValorCorrigidoSemJuros()
        {
            ContasPagar cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), new DateTime(2020, 09, 30), 100);                        
            Assert.Equal(cp.ValorOriginal, cp.ContasPagarBaixa.ValorPago);
        }

        [Fact]
        public void PagamentoNoDiaDoVencimentoValorCorrigidoSemJuros()
        {
            ContasPagar cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), new DateTime(2020, 10, 1), 100);                        
            Assert.Equal(cp.ValorOriginal, cp.ContasPagarBaixa.ValorPago);
        }

        [Theory]        
        [InlineData("2020-10-2", 100, 102.10)]
        [InlineData("2020-10-3", 100, 102.20)]
        [InlineData("2020-10-4", 100, 102.30)]
        [InlineData("2020-10-2", 200, 204.20)]
        [InlineData("2020-10-3", 200, 204.40)]
        [InlineData("2020-10-4", 200, 204.60)]
        public void PagamentoAteTresDiasDeAtraso(string dataPagamento, decimal valorOriginal, decimal valorCorrigido)
        {
            ContasPagar cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), DateTime.Parse(dataPagamento), valorOriginal);            
            Assert.Equal(valorCorrigido, cp.ContasPagarBaixa.ValorPago);
        }

        [Theory]
        [InlineData("2020-10-5", 100, 103.80)]
        [InlineData("2020-10-6", 100, 104.00)]
        [InlineData("2020-10-5", 200, 207.60)]
        [InlineData("2020-10-6", 200, 208.00)]
        public void PagamentoDeTresACincoDiasDeAtraso(string dataPagamento, decimal valorOriginal, decimal valorCorrigido)
        {
            ContasPagar cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), DateTime.Parse(dataPagamento), valorOriginal);
            Assert.Equal(valorCorrigido, cp.ContasPagarBaixa.ValorPago);
        }

        [Theory]
        [InlineData("2020-10-7", 100, 106.80)]
        [InlineData("2020-10-8", 100, 107.10)]
        [InlineData("2020-10-7", 200, 213.60)]
        [InlineData("2020-10-8", 200, 214.20)]
        public void PagamentoSuperiorACincoDiasDeAtraso(string dataPagamento, decimal valorOriginal, decimal valorCorrigido)
        {
            ContasPagar cp = new ContasPagar("Teste", new DateTime(2020, 10, 1), DateTime.Parse(dataPagamento), valorOriginal);
            Assert.Equal(valorCorrigido, cp.ContasPagarBaixa.ValorPago);
        }
    }
}
