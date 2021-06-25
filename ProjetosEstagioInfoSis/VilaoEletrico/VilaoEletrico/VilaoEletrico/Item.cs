﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VilaoEletrico
{
    public class Item 
    {
        private string nome;
        private string local;
        private double consumo;
        private double tempoDeUso;

        /// <summary>
        /// Metodo que efetua a leitura dos dados e atribui aos campos.
        /// </summary>
        public void PreencherItem()
        {
            this.ImprimeItem();
            Console.WriteLine("\nDigite o nome do item:");
            this.nome = Console.ReadLine();
            
            Console.Clear();
            this.ImprimeItem();
            Console.WriteLine("\nDigite o local do item:");
            this.local = Console.ReadLine();
            
            Console.Clear();
            this.ImprimeItem();
            this.LeConsumo(); 
           
            Console.Clear();
            this.ImprimeItem();
            this.LeTempoDeUso();
            
            Console.Clear();
            
        }

        /// <summary>
        /// Metodo que faz a leitura do Consumo
        /// </summary>
        private void LeConsumo()
        {
            string valor;
            Console.WriteLine("\nDigite o valor do consumo em w/h:");
            do
            {
                valor = Console.ReadLine();

            } while (!double.TryParse(valor, out this.consumo));
        }

        /// <summary>
        /// Metodo que faz leitura do tempo de uso.
        /// </summary>
        private void LeTempoDeUso()
        {
            string valor;
            Console.WriteLine("\nDigite o valor do tempo de uso em horas por dia:");
            do
            {
                valor = Console.ReadLine();

            } while (!double.TryParse(valor, out this.tempoDeUso));
        }

        /// <summary>
        /// Metodo que imprime os dados de um Item.
        /// </summary>
        public void ImprimeItem() 
        {
            Console.WriteLine("Nome do Item: " + this.nome);
            Console.WriteLine("Local: "+ this.local);
            Console.WriteLine("Consumo: "+ this.consumo + " W/h");
            Console.WriteLine("Tempo de Uso: "+ this.tempoDeUso + " h/dia");
        }

        public double GetTempoDeUso() 
        {
            return this.tempoDeUso;
        }
        public double GetConsumo() 
        {
            return this.consumo;
        }
    }
}
