namespace DesignPatterns.Core.Structural.Composite.Examples._01_Basic;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Composite Pattern - Ejemplo Básico: Menu System ===\n");

        // Crear menú principal
        var mainMenu = new Menu("MENÚ PRINCIPAL");

        // Crear submenús
        var fileMenu = new Menu("Archivo");
        fileMenu.Add(new MenuAction("Nuevo", () => Console.WriteLine("Creando nuevo archivo...")));
        fileMenu.Add(new MenuAction("Abrir", () => Console.WriteLine("Abriendo archivo...")));
        fileMenu.Add(new MenuAction("Guardar", () => Console.WriteLine("Guardando archivo...")));

        var editMenu = new Menu("Editar");
        editMenu.Add(new MenuAction("Cortar", () => Console.WriteLine("Cortando...")));
        editMenu.Add(new MenuAction("Copiar", () => Console.WriteLine("Copiando...")));
        editMenu.Add(new MenuAction("Pegar", () => Console.WriteLine("Pegando...")));

        var viewMenu = new Menu("Ver");
        viewMenu.Add(new MenuAction("Zoom In", () => Console.WriteLine("Ampliando...")));
        viewMenu.Add(new MenuAction("Zoom Out", () => Console.WriteLine("Reduciendo...")));

        // Agregar submenús al menú principal
        mainMenu.Add(fileMenu);
        mainMenu.Add(editMenu);
        mainMenu.Add(viewMenu);
        mainMenu.Add(new MenuAction("Salir", () => Console.WriteLine("Cerrando aplicación...")));

        // Mostrar menú
        mainMenu.Display();

        // Ejecutar acciones
        Console.WriteLine("\n--- Ejecutando acciones ---");
        fileMenu.ExecuteItem(0);
        editMenu.ExecuteItem(1);
        viewMenu.ExecuteItem(0);

        Console.WriteLine("\n Composite permite tratar menús y acciones uniformemente");
    }
}