using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_UH
{
    internal class clsMenu
    {
        int opc = 0;
        private clsEmpleado[] empleados;
        private int num_Empleados;

        public clsMenu(int capacidad)
        {
            empleados = new clsEmpleado[capacidad];
            num_Empleados = 0;
        }

        public void mostrar_Menu()
        {
            do
            {
                Console.WriteLine("¡Bienvenido a Bull & CO.!");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1- Agregar empleados \n2- Consultar empleados \n3- Modificar empleados " +
                    "\n4- Borrar empleado \n5- Reportes \n6- Inicializar arreglos \n7- Salir del programa");
                Console.WriteLine("-------------------------");

                opc = int.Parse(Console.ReadLine());
              
                switch (opc)
                {
                    case 1:

                        agregar_Empleados();

                        break;

                    case 2:

                        consultar_Empleados();

                        break;

                    case 3:

                        modificar_Empleados();

                        break;

                    case 4:

                        borrar_Empleados();

                        break;

                    case 5:

                        submenu_Reportes();

                        break;

                    case 6:

                        inicializar_Arreglos();

                        break;

                    case 7:

                        Environment.Exit(0);

                        break;

                }

            } while (opc != 0);

        }

        public void agregar_Empleados()
        {
            if (num_Empleados < empleados.Length)
            {
                Console.WriteLine("\nIngrese el nombre del empleado:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese el número de cédula del empleado:");
                string cedula = Console.ReadLine();

                Console.WriteLine("Ingrese la dirección del empleado:");
                string direccion = Console.ReadLine();

                Console.WriteLine("Ingrese el teléfono del empleado:");
                string telefono = Console.ReadLine();

                Console.WriteLine("Ingrese el salario del empleado:");
                float salario;

                string entrada = Console.ReadLine();
                if (float.TryParse(entrada, out salario))
                {
                    clsEmpleado empleado = new clsEmpleado(nombre, cedula, direccion, telefono, salario);
                    empleados[num_Empleados] = empleado;
                    num_Empleados++;
                    Console.WriteLine("\n¡Empleado agregado con éxito!");

                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Console.WriteLine("\nSalario es inválido, ingrese al empleado de nuevo");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            else 
            {
                Console.WriteLine("\nNo puedes agregar más empleados, la lista llegó a su máximo");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public void consultar_Empleados()
        {
            int contador = empleados.Count(num_Empleados => num_Empleados != null);

            if (contador == 0)
            {
                Console.WriteLine("\nNo hay ningún empleado registrado, registra alguno");
                Console.ReadKey();
                Console.Clear();
            }

            else 
            {
                Console.WriteLine("\nIngrese la cédula del empleado que desea consultar:");
                string cedula = Console.ReadLine();
                clsEmpleado empleado_Consultar = empleados.FirstOrDefault(e =>e != null && e.Cedula.Equals(cedula,StringComparison.OrdinalIgnoreCase));

                if (empleado_Consultar != null)
                {
                    Console.WriteLine("\n¡Empleado encontrado!");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Nombre: {empleado_Consultar.Nombre} || Cédula: {empleado_Consultar.Cedula} || Dirección: {empleado_Consultar.Direccion} || Teléfono: {empleado_Consultar.Telefono} || Salario: {empleado_Consultar.Salario}");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------");

                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    Console.WriteLine("\nEl empleado no está registrado, prueba de nuevo");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void modificar_Empleados()
        {
            int contador = empleados.Count(num_Empleados => num_Empleados != null);

            if (contador == 0)
            {
                Console.WriteLine("\nNo hay ningún empleado registrado");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                Console.WriteLine("\nIngrese la cédula del empleado que desea modificar: ");
                string cedula = Console.ReadLine();
                int verificar = -1;

                for (int i = 0; i < empleados.Length; i++)
                {
                    if (empleados[i] != null && empleados[i].Cedula.Equals(cedula, StringComparison.OrdinalIgnoreCase))
                    {
                        verificar = i;
                        break;
                    }

                }

                if (verificar != -1)
                {
                    clsEmpleado empleado_Modificar = empleados[verificar];

                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine($"Empleado encontrado, el empleado {empleado_Modificar.Nombre} será modificado");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("\n¿Qué modificación deseas realizar? \n1- Nombre \n2- Dirección \n3- Teléfono \n4- Salario");
                    int opc = 0;

                    if (int.TryParse(Console.ReadLine(), out opc) && opc >= 1 && opc <= 4)
                    {
                        switch (opc)
                        {
                            case 1:

                                Console.WriteLine("\n¿Cuál será el nuevo nombre del empleado?:");
                                empleado_Modificar.Nombre = Console.ReadLine();

                                Console.WriteLine("\nEl empleado se modificó con éxito");
                                Console.ReadKey();
                                Console.Clear();

                                break;

                            case 2:

                                Console.WriteLine("\n¿Cuál será la nueva dirección del empelado?:");
                                empleado_Modificar.Direccion = Console.ReadLine();

                                Console.WriteLine("\nEl empleado se modificó con éxito");
                                Console.ReadKey();
                                Console.Clear();

                                break;

                            case 3:

                                Console.WriteLine("\n¿Cuál será el nuevo número teléfonico del empleado?:");
                                empleado_Modificar.Telefono = Console.ReadLine();

                                Console.WriteLine("\nEl empleado se modificó con éxito");
                                Console.ReadKey();
                                Console.Clear();

                                break;

                            case 4:

                                Console.WriteLine("\n¿Cuál será el nuevo salario del empleado?:");

                                if (float.TryParse(Console.ReadLine(), out float salario))
                                {
                                    empleado_Modificar.Salario = salario;

                                    Console.WriteLine("\nEl empleado se modificó con éxito");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                else
                                {
                                    Console.WriteLine("\nSe dígito mal el nuevo salario, inténtelo de nuevo");
                                    Console.ReadKey();
                                    Console.Clear();
                                }

                                break;
                        }

                    }

                    else
                    {
                        Console.WriteLine("\nOpción inválida, prueba una opción válida");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                else
                {
                    Console.WriteLine("\nCédula no existente, digita la cédula de nuevo");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        public void borrar_Empleados()
        {
            int contador = empleados.Count(num_Empleados => num_Empleados != null);

            if (contador == 0)
            {
                Console.WriteLine("\nNo hay ningún empleado registrado");
                Console.ReadKey();
                Console.Clear();
            }

            else 
            {
                Console.WriteLine("\nDigite la cédula del empleado que desea eliminar:");
                string cedula = Console.ReadLine();

                for (int i = 0; i < contador; i++)
                {
                    if (empleados[i] != null && empleados[i].Cedula.Equals(cedula, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\nEl empleado {empleados[i].Nombre} se ha borrado");
                        empleados[i] = null;
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    else
                    {
                        Console.WriteLine("\nEl empleado no existe, digita la cédula de nuevo");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                }
            }
        }   

        public void inicializar_Arreglos()
        {
            int contador = empleados.Count(num_Empleados => num_Empleados != null);

            if (contador == 0)
            {
                Console.WriteLine("\nNo hay ningún empleado registrado");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                for (int i = 0; i < empleados.Length; i++)
                {
                    empleados[i] = null;
                }

                Console.WriteLine("\nLos empleados se eliminaron con éxito, introduzca otro nuevamente");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void submenu_Reportes() 
        {
            do
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Submenú reportes");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1- Listar empleados \n2- Promedio de salarios \n3- Salario más bajo y alto \n4- Volver al menú principal");
                Console.WriteLine("------------------------------");

                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:

                        listar_Empleados();

                        break;

                    case 2:

                        promedio_Salarios();

                        break;

                    case 3:

                        calculo_Salarios(out float salario_Alto, out float salario_Bajo);

                        break;

                    case 4:

                        Console.ReadKey();
                        Console.Clear();
                        mostrar_Menu();

                        break; 

                }

            } while (opc != 0);
        }

        public void listar_Empleados() 
        {
            int contador = empleados.Count(num_Empleados => num_Empleados != null);

            if (contador > 0) 
            {
                for (int i = 0; i < contador - 1; i++) 
                {
                    for (int j = i + 1; j < contador; j++)
                    {
                        if (empleados[i] != null && empleados[j] != null && string.Compare(empleados[i].Nombre, empleados[j].Nombre, StringComparison.Ordinal) > 0) 
                        {
                            clsEmpleado EMP = empleados[i];
                            empleados[i] = empleados[j]; 
                            empleados[j] = EMP;
                        }
                    }
                }

                Console.WriteLine("\nEmpleados ordenados por nombre");

                foreach (var empleado in  empleados) 
                {
                    if (empleado != null)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Nombre: {empleado.Nombre} || Cédula: {empleado.Cedula} || Dirección: {empleado.Direccion}" +
                            $" || Teléfono: {empleado.Telefono} || Salario: {empleado.Salario} ");
                        Console.WriteLine("-------------------------------------------------------------------------------------------------");
                    }
                }
            }

            else 
            {
                Console.WriteLine("\nNo hay empleados para generar reportes");
            }
        }

        public float promedio_Salarios()
        {
            float suma_Salarios = 0;
            int contador_Empleados = 0;

            foreach (var empleado in empleados) 
            {
                if (empleado != null) 
                {
                    suma_Salarios += empleado.Salario;
                    contador_Empleados++;
                }
            }

            if (contador_Empleados > 0) 
            {
                float promedio = suma_Salarios / contador_Empleados;
                Console.WriteLine("\n----------------------------------------");
                Console.WriteLine($"El promedio de salarios es de {promedio}");
                Console.WriteLine("----------------------------------------");
                return promedio;
            }

            else 
            {
                return 0;
            }
        }

        public void calculo_Salarios(out float salario_Alto, out float salario_Bajo) 
        {
            salario_Alto = float.MinValue;
            salario_Bajo = float.MaxValue;
            clsEmpleado empleado_Alto = null;
            clsEmpleado empleado_Bajo = null;
           
            foreach (var empleado in empleados)
            {
                if (empleado != null)
                {
                    if (empleado.Salario > salario_Alto) 
                    {
                        salario_Alto = empleado.Salario;
                        empleado_Alto = empleado;
                    }

                    if (empleado.Salario < salario_Bajo)
                    {
                        salario_Bajo = empleado.Salario;
                        empleado_Bajo = empleado;
                    }
                }
            }

            if (empleado_Alto != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine($"El empleado {empleado_Alto.Nombre} tiene el salario más alto de {salario_Alto}");
                Console.WriteLine("-------------------------------------------------------------------------------");
            }

            if (empleado_Bajo != null)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine($"El empleado {empleado_Bajo.Nombre} tiene el salario más bajo de {salario_Bajo}");
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }
    }
}