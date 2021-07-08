
using System.IO;
using System;

namespace TRANSFERENCIA.Src
{
    public class Conta
    {
        
        private TipoConta TipoConta {get;  set;}

        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}
         private int Agencia {get; set;}

        private int NumeroConta {get;set;}
            public  Conta (TipoConta tipoConta, double saldo, double credito, string nome, int Agencia, int NumeroConta){

                this.TipoConta = tipoConta;
                this.Saldo = saldo;
                this.Credito = credito;
                this.Nome = nome;
                this.Agencia = Agencia;
                this.NumeroConta = NumeroConta;
    }
        
        
            public bool Sacar(  double ValorSaque){

                if (this.Saldo  - ValorSaque < (this.Credito * -1)){

                    Console.WriteLine("Saldo Insuficiente");
                    return false;

                }

                  this.Saldo -= ValorSaque;
                Console.WriteLine("Saldo atual da Conta de {0} é {1}", this.Nome, this.Saldo); 
                StreamWriter Sw;
                DateTime data = DateTime.Now;
                var caminho = "";

             //caminho de acordo com da sua maquina
            caminho = "\\Users\\BRUNO BARROS\\Desktop\\Projeto Github\\Transferencia\\txt\\Histotico_de_saque";
            Sw = File.AppendText(caminho);
            
            Sw.WriteLine("Saque nesse período {0}", data);
            Sw.WriteLine("Conta: {0}", this.Nome);
            Sw.WriteLine("Tipo de Conta: {0}", this.TipoConta);
            Sw.WriteLine("Agência: {0}", this.Agencia);
            Sw.WriteLine("Numero da Conta: {0}", this.NumeroConta);
            Sw.WriteLine("O valor do saque foi -{0}",ValorSaque);      
            Sw.WriteLine("Saldo atual: {0}",this.Saldo);      
            Sw.WriteLine("____________________________________");
            Sw.Close();

              
                    return true;
            }
             public void Depositar(double ValorDeposito){

                 
                 this.Saldo += ValorDeposito;
                 Console.WriteLine("Saldo atual da Conta de {0} é {1}", this.Nome, this.Saldo);
                

                StreamWriter Sw;
                DateTime data = DateTime.Now;

             //caminho de acordo com da sua maquina
            var caminho = "\\Users\\BRUNO BARROS\\Desktop\\Projeto Github\\Transferencia\\txt\\Histotico_de_deposito";
            Sw = File.AppendText(caminho);

            Sw.WriteLine("Deposito nesse período: {0}", data);
            Sw.WriteLine("Conta: {0}", this.Nome);
            Sw.WriteLine("Tipo de Conta: {0}", this.TipoConta);
            Sw.WriteLine("Agência: {0}", this.Agencia);
            Sw.WriteLine("Numero da Conta: {0}", this.NumeroConta);
            Sw.WriteLine("O valor do Depósito: +{0}",ValorDeposito);   
             Sw.WriteLine("Saldo atual: {0}",this.Saldo);      
            Sw.WriteLine("____________________________________");
            Sw.Close();




             }
                public void Transferir(double ValorTransfarencia, Conta ContaDestino, TipoTransferencia tipoTransferencia){
                if (this.Sacar(ValorTransfarencia)){
                ContaDestino.Depositar(ValorTransfarencia);

                StreamWriter Sw;
                DateTime data = DateTime.Now;

             //caminho de acordo com da sua maquina
            var caminho = "\\Users\\BRUNO BARROS\\Desktop\\Projeto Github\\Transferencia\\txt\\Histotico_de_transferencia";
            Sw = File.AppendText(caminho);

            Sw.WriteLine("Transferência nesse período: {0}", data);
            Sw.WriteLine("Tipo de Transação: {0}",tipoTransferencia);
           Sw.WriteLine("Conta Origem: {0}", this.Nome);
            Sw.WriteLine("Conta destino: {0}", ContaDestino.Nome);
            Sw.WriteLine("Tipo de Conta: {0}", ContaDestino.TipoConta);
            Sw.WriteLine("Agência: {0}", ContaDestino.Agencia);
            Sw.WriteLine("Numero da Conta: {0}", ContaDestino.NumeroConta);
            Sw.WriteLine("O valor da Transferência: +{0}",ValorTransfarencia);      
            Sw.WriteLine("____________________________________");
            Sw.Close();


                }


                }

                public override string ToString(){
                    string retorno = "";

                    retorno += "Agência: " + this.Agencia + Environment.NewLine;
                    retorno += "Numero da Conta:" + this.NumeroConta + Environment.NewLine;
                    retorno += "Tipo de Conta: " +this.TipoConta + Environment.NewLine;
                    retorno += "Nome: " + this.Nome + Environment.NewLine;
                    retorno += "Saldo: " + this.Saldo + Environment.NewLine;
                    retorno += "Credito: " + this.Credito ;

                    return retorno;



                }

           






        }



}