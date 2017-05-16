using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public class Program
    {



        public static void Main()
        {

            Sistema metodo = new Sistema();

            Console.WriteLine("Seleccione el Servicio Deseado" + "\n 1: Transporte" + "\n 2:Encomienda" + "\n 3:Ingresar Empleado" + "\n 4:Ingresar Vehiculo" + "\n 5:Mostrar Relacion de Ventas");
            String seleccion = Console.Read().ToString();
            switch (seleccion)
            {
                case "1":
                    Console.WriteLine("Servicio de Transporte Seleccionado");
                    metodo.RealizarTransporte();
                    break;

                case "2":
                    Console.WriteLine("Servicio de Encomienda Seleccionado");
                    metodo.RealizarEncomienda();
                    break;

                case "3":
                    Console.WriteLine("Ingresar un Nuevo Empleado  Seleccionado");



                    break;


                case "4":
                    Console.WriteLine("Ingresar un Nuevo Vehiculo  Seleccionado");

                    break;

                case "5":
                    Console.WriteLine("Mostrar Relacion de Ventas  Seleccionado");
                    metodo.MostrarVentas();
                    break;
            }
        }


    }     

        
    }     
