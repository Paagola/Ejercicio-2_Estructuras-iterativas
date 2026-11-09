using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Ejercicio1();
        Ejercicio2();
        Ejercicio3();
        Ejercicio4();
        Ejercicio5();
        Ejercicio6();
        Ejercicio7();
        Ejercicio8();
        Ejercicio9();
        Ejercicio10();
        Ejercicio11();
    }

    // 1. Indicar cuál de dos números es mayor.
    static void Ejercicio1()
    {
        Console.WriteLine("\n--- Ejercicio 1 ---");

        Console.Write("Introduce el primer número: ");
        int numero1 = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Introduce el segundo número: ");
        int numero2 = int.Parse(Console.ReadLine() ?? "0");

        // Una sola llamada a WriteLine y sin concatenar cadenas.
        Console.WriteLine(numero1 > numero2
            ? $"El número mayor es {numero1}"
            : numero2 > numero1
                ? $"El número mayor es {numero2}"
                : "Los dos números son iguales");
    }

    // 2. Calcular el coste de la factura de la luz.
    static void Ejercicio2()
    {
        Console.WriteLine("\n--- Ejercicio 2 ---");

        Console.Write("Introduce los kilovatios consumidos: ");
        decimal kilovatios = decimal.Parse(Console.ReadLine() ?? "0");

        if (kilovatios < 0)
        {
            Console.WriteLine("El consumo no puede ser negativo.");
            return;
        }

        decimal precioKilovatio;

        // Se respetan los precios escritos en el enunciado: 0,8; 0,12 y 0,14.
        if (kilovatios > 1800)
        {
            precioKilovatio = 0.8m;
        }
        else if (kilovatios >= 1000)
        {
            precioKilovatio = 0.12m;
        }
        else
        {
            precioKilovatio = 0.14m;
        }

        decimal total = kilovatios * precioKilovatio;

        Console.WriteLine($"Precio por kilovatio aplicado: {precioKilovatio:0.00} €");
        Console.WriteLine($"Total a pagar: {total:0.00} €");
    }

    // 3. Mostrar el estado civil según una letra, usando switch/case.
    static void Ejercicio3()
    {
        Console.WriteLine("\n--- Ejercicio 3 ---");

        Console.Write("Introduce tu estado civil (C, S, V o D): ");
        string estado = (Console.ReadLine() ?? "").Trim().ToUpper();

        switch (estado)
        {
            case "C":
                Console.WriteLine("Tu estado civil es Casad@");
                break;
            case "S":
                Console.WriteLine("Tu estado civil es Solter@");
                break;
            case "V":
                Console.WriteLine("Tu estado civil es Viud@");
                break;
            case "D":
                Console.WriteLine("Tu estado civil es Divorciad@");
                break;
            default:
                Console.WriteLine("La opción introducida no es correcta.");
                break;
        }
    }
    // 4. Mostrar la tabla de multiplicar de un número entre 1 y 9.
    static void Ejercicio4()
    {
        Console.WriteLine("\n--- Ejercicio 4 ---");

        int numero;
        Console.Write("Introduce un número del 1 al 9: ");

        while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1 || numero > 9)
        {
            Console.Write("Valor incorrecto. Introduce un número del 1 al 9: ");
        }

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numero} x {i} = {numero * i}");
        }
    }

    // 5. Realizar distintas operaciones con una cadena de texto.
    static void Ejercicio5()
    {
        Console.WriteLine("\n--- Ejercicio 5 ---");

        Console.Write("Introduce una cadena de texto: ");
        string texto = Console.ReadLine() ?? "";

        Console.WriteLine($"Longitud de la cadena: {texto.Length}");

        Console.Write("Introduce una subcadena que quieras buscar: ");
        string subcadena = Console.ReadLine() ?? "";
        Console.WriteLine($"¿Contiene '{subcadena}'?: {texto.Contains(subcadena)}");

        char letraAntigua = LeerCaracter("Introduce la letra que quieres reemplazar: ");
        char letraNueva = LeerCaracter("Introduce la nueva letra: ");
        Console.WriteLine($"Cadena con el reemplazo: {texto.Replace(letraAntigua, letraNueva)}");

        Console.WriteLine($"En mayúsculas: {texto.ToUpper()}");
        Console.WriteLine($"En minúsculas: {texto.ToLower()}");

        if (texto.Length > 0)
        {
            int posicionEliminar;
            Console.Write($"Indica la posición del carácter que quieres eliminar (0 a {texto.Length - 1}): ");

            while (!int.TryParse(Console.ReadLine(), out posicionEliminar)
                   || posicionEliminar < 0 || posicionEliminar >= texto.Length)
            {
                Console.Write($"Posición incorrecta. Introduce un valor entre 0 y {texto.Length - 1}: ");
            }

            Console.WriteLine($"Cadena sin ese carácter: {texto.Remove(posicionEliminar, 1)}");

            int inicio;
            Console.Write($"Indica la posición inicial de la subcadena (0 a {texto.Length - 1}): ");
            while (!int.TryParse(Console.ReadLine(), out inicio)
                   || inicio < 0 || inicio >= texto.Length)
            {
                Console.Write($"Posición incorrecta. Introduce un valor entre 0 y {texto.Length - 1}: ");
            }

            int fin;
            Console.Write($"Indica la posición final (entre {inicio} y {texto.Length - 1}): ");
            while (!int.TryParse(Console.ReadLine(), out fin)
                   || fin < inicio || fin >= texto.Length)
            {
                Console.Write($"Posición incorrecta. Introduce un valor entre {inicio} y {texto.Length - 1}: ");
            }

            // Substring recibe la posición inicial y la cantidad de caracteres.
            // Por eso sumamos 1 para incluir también la posición final indicada.
            string resultadoSubcadena = texto.Substring(inicio, fin - inicio + 1);
            Console.WriteLine($"Subcadena desde {inicio} hasta {fin}: {resultadoSubcadena}");
        }
        else
        {
            Console.WriteLine("La cadena está vacía; no se puede eliminar un carácter ni extraer una subcadena.");
        }
    }

    // Método auxiliar para asegurarnos de que se introduce exactamente un carácter.
    static char LeerCaracter(string mensaje)
    {
        Console.Write(mensaje);
        string entrada = Console.ReadLine() ?? "";

        while (entrada.Length != 1)
        {
            Console.Write("Debes introducir exactamente un carácter: ");
            entrada = Console.ReadLine() ?? "";
        }

        return entrada[0];
    }

    // 6. Calcular el factorial de un número.
    static void Ejercicio6()
    {
        Console.WriteLine("\n--- Ejercicio 6 ---");

        int numero;
        Console.Write("Introduce un número entero entre 0 y 20: ");

        // Se limita a 20 porque 20! cabe en un long y 21! ya no.
        while (!int.TryParse(Console.ReadLine(), out numero) || numero < 0 || numero > 20)
        {
            Console.Write("Valor incorrecto. Introduce un número entre 0 y 20: ");
        }

        long factorial = 1;

        for (int i = 1; i <= numero; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"El factorial de {numero} es {factorial}");
    }

    // 7. Mostrar el abecedario desde la Z hasta la A usando códigos ASCII.
    static void Ejercicio7()
    {
        Console.WriteLine("\n--- Ejercicio 7 ---");

        for (int codigo = 90; codigo >= 65; codigo--)
        {
            Console.Write(Convert.ToString((char)codigo) + " ");
        }

        Console.WriteLine();
    }

    // 8. Generar un número aleatorio entre 10 y 30, ambos incluidos.
    static void Ejercicio8()
    {
        Console.WriteLine("\n--- Ejercicio 8 ---");

        Random aleatorio = new Random();
        int numero = aleatorio.Next(10, 31); // El límite superior de Next no se incluye.

        Console.WriteLine($"Número aleatorio: {numero}");
    }

    // 9. Crear un array del tamaño indicado y clasificar sus valores como pares o impares.
    static void Ejercicio9()
    {
        Console.WriteLine("\n--- Ejercicio 9 ---");

        int tamano;
        Console.Write("¿Cuántos números quieres introducir?: ");

        while (!int.TryParse(Console.ReadLine(), out tamano) || tamano <= 0)
        {
            Console.Write("Introduce un tamaño válido mayor que cero: ");
        }

        int[] numeros = new int[tamano];

        for (int i = 0; i < numeros.Length; i++)
        {
            Console.Write($"Introduce el número de la posición {i}: ");
            while (!int.TryParse(Console.ReadLine(), out numeros[i]))
            {
                Console.Write("Valor incorrecto. Introduce un número entero: ");
            }
        }

        Console.WriteLine("Valores pares:");
        for (int i = 0; i < numeros.Length; i++)
        {
            if (numeros[i] % 2 == 0)
            {
                Console.WriteLine(numeros[i]);
            }
        }

        Console.WriteLine("Valores impares:");
        for (int i = 0; i < numeros.Length; i++)
        {
            if (numeros[i] % 2 != 0)
            {
                Console.WriteLine(numeros[i]);
            }
        }
    }

    // 10. Ordenar un array de 10 enteros utilizando System.Array.Sort.
    static void Ejercicio10()
    {
        Console.WriteLine("\n--- Ejercicio 10 ---");

        int[] numeros = { 23, 5, 14, 2, 9, 31, 7, 18, 1, 11 };

        Array.Sort(numeros);

        Console.WriteLine("Array ordenado:");
        for (int i = 0; i < numeros.Length; i++)
        {
            Console.WriteLine(numeros[i]);
        }
    }

    // 11. Crear y utilizar una pila (Stack) de enteros.
    static void Ejercicio11()
    {
        Console.WriteLine("\n--- Ejercicio 11 ---");

        Stack pila = new Stack();

        int cantidad;
        Console.Write("¿Cuántos números quieres introducir en la pila? (mínimo 2): ");

        while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad < 2)
        {
            Console.Write("Introduce una cantidad igual o superior a 2: ");
        }

        for (int i = 0; i < cantidad; i++)
        {
            int numero;
            Console.Write($"Introduce el número {i + 1}: ");

            while (!int.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Valor incorrecto. Introduce un número entero: ");
            }

            pila.Push(numero);
        }

        Console.WriteLine("Contenido de la pila (de arriba hacia abajo):");
        foreach (object elemento in pila)
        {
            Console.WriteLine(elemento);
        }

        // Pop extrae y elimina el elemento que está en la parte superior.
        object primero = pila.Pop();
        object segundo = pila.Pop();

        Console.WriteLine($"Se han extraído los elementos {primero} y {segundo}.");

        Console.WriteLine("Contenido de la pila después de extraer dos elementos:");
        foreach (object elemento in pila)
        {
            Console.WriteLine(elemento);
        }
    }
}