﻿using ConsolaTrabajoUnidadAPI.Metodos;
using System;
using System.Net;
using System.Net.Http.Headers;


class Program
{
    static async Task Main(string[] args)
    {
        _animales = new Animales();
        _duenos = new Duenos();
        _atenciones = new Atenciones();
        var program = new Program();
        await program.MenuPrincipal();
    }
    private static Animales _animales;
    private static Duenos _duenos;
    private static Atenciones _atenciones;

    public async Task MenuPrincipal()
    {
        while (true)
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1. Menu Dueño");
            Console.WriteLine("2. Menu Animal");
            Console.WriteLine("3. Menu Atencion");
            Console.WriteLine("4. Salir");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    MenuDueno();
                    break;
                case "2":
                    MenuAnimal();
                    break;
                case "3":
                    MenuAtencion();
                    break;
                case "4":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }


    }
    public async Task MenuAnimal()
    {
        while (true)
        {
            Console.WriteLine("Menu Animal");
            Console.WriteLine("1. Crear Animal");
            Console.WriteLine("2. Editar Animal");
            Console.WriteLine("3. Eliminar Animal");
            Console.WriteLine("4. Listar Animales");
            Console.WriteLine("5. Volver al Menu Principal");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    _animales.CreateAnimalAsync();
                    break;
                case "2":
                    _animales.UpdateAnimalAsync();
                    break;
                case "3":
                    _animales.DeleteAnimalAsync();
                    break;
                case "4":
                    _animales.GetAnimalAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
    public async Task MenuDueno()
    {
        while (true)
        {
            Console.WriteLine("Menu Dueño");
            Console.WriteLine("1. Crear Dueño");
            Console.WriteLine("2. Voler al Menu Principal");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    _duenos.CreateDuenoAsync();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    public async Task MenuAtencion()
    {
        while (true)
        {
            Console.WriteLine("Menu Atencion");
            Console.WriteLine("1. Crear Atencion");
            Console.WriteLine("2. Volver al Menu Principal");
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    _atenciones.CrearAtencion();
                    break;
                case "2":
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}



   