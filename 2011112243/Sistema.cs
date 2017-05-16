using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2011112243
{
    public class Sistema
    {
        Cliente[] cliente = new Cliente[50];
        Administrativo[] administrativo = new Administrativo[50];
        Tripulacion[] tripulacion = new Tripulacion[50];
        Bus[] bus = new Bus[50];
        Encomienda[] encomienda = new Encomienda[50];
        LugarViaje[] lugarviaje = new LugarViaje[50];
        TipoComprobante[] tipocomprobante = new TipoComprobante[50];
        TipoLugar[] tipolugar = new TipoLugar[50];
        TipoPago[] tipopago = new TipoPago[50];
        TipoTripulacion[] tipotripulacion = new TipoTripulacion[50];
        Transporte[] transporte = new Transporte[50];
        Venta[] venta = new Venta[50];
        

        
        
        public void RealizarTransporte()
        {
            for (int i = 0; i < 50; i++) {
                if (transporte[i]._Bus._idBus == null)
                {

                    Random r = new Random();
                    int id = i;

                    Console.WriteLine("Ingrese los campos requeridos: \n");

                    Console.WriteLine("ID del Administrativo: ");
                    String idAdm = Console.ReadLine();
                    for (int j = 0; j < 50; j++) {
                        if (idAdm == venta[j]._Administrativo.idEmp)
                        {

                            Console.WriteLine("Nombre del CLiente: ");
                            venta[i]._Cliente.nom = Console.ReadLine();
                            Console.WriteLine("dni del CLiente: ");
                            venta[i]._Cliente.dni = Console.ReadLine();
                            Console.WriteLine("Direccion del CLiente: ");
                            venta[i]._Cliente.direccion = Console.ReadLine();
                            Console.WriteLine("Email del CLiente: ");
                            venta[i]._Cliente.email = Console.ReadLine();
                            Console.WriteLine("Origen de Transporte: ");
                            venta[i]._Servicio.Origen = Console.ReadLine();
                            Console.WriteLine("ID del Tripulante 1: ");
                            String idTripulante = Console.ReadLine();
                            for (int k = 0; k < 50; k++)
                            {
                                if (idTripulante == tripulacion[i].idEmp)
                                {
                                    Console.WriteLine("Estado de Tripulante 1");
                                    bus[k]._Tripulacion.estado = Console.ReadLine();
                                    Console.WriteLine("horas de Trabajo de Tripulante 1");
                                    bus[k]._Tripulacion.horasTrab = Console.ReadLine();
                                    Console.WriteLine("Tipo de Tripulacion de Tripulante 1 -Piloto  - Copiloto  -Azafata");
                                    bus[k]._Tripulacion._tipoTrip.tipodeTripulacion = Console.ReadLine();
                                }
                                else
                                {
                                    ;
                                }
                            }

                            Console.WriteLine("ID del Tripulante 2: ");
                            String idTripulante2 = Console.ReadLine();
                            for (int k = 0; k < 50; k++)
                            {
                                if (idTripulante == tripulacion[i].idEmp)
                                {
                                    Console.WriteLine("Estado de Tripulante 2");
                                    bus[k]._Tripulacion.estado = Console.ReadLine();
                                    Console.WriteLine("horas de Trabajo de Tripulante 2");
                                    bus[k]._Tripulacion.horasTrab = Console.ReadLine();
                                    Console.WriteLine("Tipo de Tripulacion de Tripulante 2 -Piloto  - Copiloto  -Azafata");
                                    bus[k]._Tripulacion._tipoTrip.tipodeTripulacion = Console.ReadLine();
                                }
                                else
                                {
                                }

                            }


                            Console.WriteLine("ID del Tripulante 3: ");
                            String idTripulante3 = Console.ReadLine();
                            for (int k = 0; k < 50; k++)
                            {
                                if (idTripulante == tripulacion[i].idEmp)
                                {
                                    Console.WriteLine("Estado de Tripulante 3");
                                    bus[k]._Tripulacion.estado = Console.ReadLine();
                                    Console.WriteLine("horas de Trabajo de Tripulante 3");
                                    bus[k]._Tripulacion.horasTrab = Console.ReadLine();
                                    Console.WriteLine("Tipo de Tripulacion de Tripulante 3 -Piloto  - Copiloto  -Azafata");
                                    bus[k]._Tripulacion._tipoTrip.tipodeTripulacion = Console.ReadLine();
                                }
                                else
                                {
                                }

                            }
                            Console.WriteLine("Destino Departamento: ");
                            transporte[j]._LugarViaje.dep = Console.ReadLine();
                            Console.WriteLine("Destino Ciudad: ");
                            transporte[j]._LugarViaje.ciudad = Console.ReadLine();
                            Console.WriteLine("Destino Fecha de Llegada: ");
                            transporte[j]._LugarViaje.fecha = Console.ReadLine();
                            Console.WriteLine("Destino hora aploximada de llegada: ");
                            transporte[j]._LugarViaje.horaAprox = Console.ReadLine();
                            Console.WriteLine("Tipo de Lugar  -Capital  -pueblo ");
                            transporte[j]._LugarViaje._TipoLugar.tipoLugar = Console.ReadLine();
                            Console.WriteLine("Numero de Asientos: ");
                            transporte[j].nAsientos = Console.ReadLine();
                            Console.WriteLine("Tipo de Viaje: ");
                            transporte[j]._TipoViaje.tipoViaje = Console.ReadLine();
                            Console.WriteLine("Tipo de Pago - Efectivo  -Tarjeta de Credito  -Tarjeta de Devito");
                            venta[j]._TipoPago.tipodePago = Console.ReadLine();
                            Console.WriteLine("Tipo de Comprobante -Boleta  -Factura");
                            venta[j]._tipoComprobante.TipodeComprobante = Console.ReadLine();
                            int idlv = j + 1;
                            transporte[j]._LugarViaje.idLugarViaje = idlv.ToString();
                            int idtl = j + 1;
                            transporte[j]._LugarViaje._TipoLugar.idTipoLugar = idtl.ToString();
                            venta[j].idVenta = i.ToString();
                            venta[j]._Servicio.idServicio = i.ToString();
                            venta[j]._Servicio.tipoServicio = "Transpote";
                            venta[j].Costo = r.Next(50, 150);



                        }
                        else
                        {

                        }

                    }


                }



            }
        }
        public void RealizarEncomienda()
        {
            for (int i = 0; i < 50; i++)
            {
                if (transporte[i]._Bus._idBus == null)
                {

                    Random r = new Random();
                    int id = i;

                    Console.WriteLine("Ingrese los campos requeridos: \n");

                    Console.WriteLine("ID del Administrativo: ");
                    String idAdm = Console.ReadLine();
                    for (int j = 0; j < 50; j++)
                    {
                        if (idAdm == venta[j]._Administrativo.idEmp)
                        {

                            Console.WriteLine("Nombre del CLiente: ");
                            venta[i]._Cliente.nom = Console.ReadLine();
                            Console.WriteLine("dni del CLiente: ");
                            venta[i]._Cliente.dni = Console.ReadLine();
                            Console.WriteLine("Direccion del CLiente: ");
                            venta[i]._Cliente.direccion = Console.ReadLine();
                            Console.WriteLine("Email del CLiente: ");
                            venta[i]._Cliente.email = Console.ReadLine();
                            Console.WriteLine("Origen de Transporte: ");
                            venta[i]._Servicio.Origen = Console.ReadLine();
                            Console.WriteLine("ID del Tripulante 1: ");
                            String idTripulante = Console.ReadLine();
                            for (int k = 0; k < 50; k++)
                            {
                                if (idTripulante == tripulacion[i].idEmp)
                                {
                                    Console.WriteLine("Estado de Tripulante 1");
                                    bus[k]._Tripulacion.estado = Console.ReadLine();
                                    Console.WriteLine("horas de Trabajo de Tripulante 1");
                                    bus[k]._Tripulacion.horasTrab = Console.ReadLine();
                                    Console.WriteLine("Tipo de Tripulacion de Tripulante 1 -Piloto  - Copiloto  -Azafata");
                                    bus[k]._Tripulacion._tipoTrip.tipodeTripulacion = Console.ReadLine();
                                }
                                else
                                {
                                }
                            }

                            Console.WriteLine("ID del Tripulante 2: ");
                            String idTripulante2 = Console.ReadLine();
                            for (int k = 0; k < 50; k++)
                            {
                                if (idTripulante == tripulacion[i].idEmp)
                                {
                                    Console.WriteLine("Estado de Tripulante 2");
                                    bus[k]._Tripulacion.estado = Console.ReadLine();
                                    Console.WriteLine("horas de Trabajo de Tripulante 2");
                                    bus[k]._Tripulacion.horasTrab = Console.ReadLine();
                                    Console.WriteLine("Tipo de Tripulacion de Tripulante 2 -Piloto  - Copiloto  -Azafata");
                                    bus[k]._Tripulacion._tipoTrip.tipodeTripulacion = Console.ReadLine();
                                }
                                else
                                {
                                }

                            }


                            Console.WriteLine("ID del Tripulante 3: ");
                            String idTripulante3 = Console.ReadLine();
                            for (int k = 0; k < 50; k++)
                            {
                                if (idTripulante == tripulacion[i].idEmp)
                                {
                                    Console.WriteLine("Estado de Tripulante 3");
                                    bus[k]._Tripulacion.estado = Console.ReadLine();
                                    Console.WriteLine("horas de Trabajo de Tripulante 3");
                                    bus[k]._Tripulacion.horasTrab = Console.ReadLine();
                                    Console.WriteLine("Tipo de Tripulacion de Tripulante 3 -Piloto  - Copiloto  -Azafata");
                                    bus[k]._Tripulacion._tipoTrip.tipodeTripulacion = Console.ReadLine();
                                }
                                else
                                {
                                }

                            }
                            Console.WriteLine("Destino Departamento: ");
                            transporte[j]._LugarViaje.dep = Console.ReadLine();
                            Console.WriteLine("Destino Ciudad: ");
                            transporte[j]._LugarViaje.ciudad = Console.ReadLine();
                            Console.WriteLine("Destino Fecha de Llegada: ");
                            transporte[j]._LugarViaje.fecha = Console.ReadLine();
                            Console.WriteLine("Destino hora aploximada de llegada: ");
                            transporte[j]._LugarViaje.horaAprox = Console.ReadLine();
                            Console.WriteLine("Peso Encomienda: ");
                            encomienda[j].peso = Console.ReadLine();
                            Console.WriteLine("Dimensiones Encomienda: ");
                            encomienda[j].dimensiones = Console.ReadLine();
                            Console.WriteLine("numero de bultos en Encomienda: ");
                            encomienda[j].nbultos = Console.ReadLine();
                            Console.WriteLine("Tipo de Pago - Efectivo  -Tarjeta de Credito  -Tarjeta de Devito");
                            venta[j]._TipoPago.tipodePago = Console.ReadLine();
                            Console.WriteLine("Tipo de Comprobante -Boleta  -Factura");
                            venta[j]._tipoComprobante.TipodeComprobante = Console.ReadLine();
                            int idlv = j + 1;
                            transporte[j]._LugarViaje.idLugarViaje = idlv.ToString();
                            int idtl = j + 1;
                            transporte[j]._LugarViaje._TipoLugar.idTipoLugar = idtl.ToString();
                            venta[j].idVenta = i.ToString();
                            venta[j]._Servicio.idServicio = i.ToString();
                            venta[j]._Servicio.tipoServicio = "Encomienda";
                            venta[j].Costo = r.Next(50, 150);



                        }
                        else
                        {

                        }

                    }


                }


            }
        } 


            public void IngresarVehiculo()
        {

        }

        public void IngresarEmpleado()
        {

        }


        public void MostrarVentas()
        {
            for (int i = 0; i < 50; i++)
            {
                if (venta[0].idVenta == null)
                {
                    Console.WriteLine("No existen ventas");
                    Console.WriteLine("¿Volver al inicio?" + "\n [y/n]");

                    String seleccionar = Console.ReadKey().ToString();
                    if (seleccionar == "y")
                    {

                    }
                }
                else if (venta[i].idVenta == null)
                {


                    Console.WriteLine("¿Volver al inicio?" + "\n [y/n]");

                    String seleccionar = Console.ReadKey().ToString();
                    if (seleccionar == "y")
                    {

                    }
                }
                else
                {
                    Console.WriteLine("[i+1]");
                    Console.WriteLine("\n Codigo de Venta: " + venta[i].idVenta + "\n Tipo de Servicio: " + venta[i]._Servicio.tipoServicio + "\n Tipo de Pago: " + venta[i]._TipoPago.tipodePago + "\n Tipo de Comprobante: " + venta[i]._tipoComprobante.TipodeComprobante + "\n dni del cliente: " + venta[i]._Cliente.dni + "\n Nombre del Cliente: "
                        + venta[i]._Cliente.nom + "\nEncargado de la venta" + venta[i]._Administrativo.nom + " " + venta[i]._Administrativo.apePat + " " + venta[i]._Administrativo.apeMat + "\n Costo: " + venta[i].Costo);

                }
            
            }

        }
    }
}
