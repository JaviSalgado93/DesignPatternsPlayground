namespace DesignPatterns.Core.Structural.Decorator.Examples._02_Advanced;

public class Demo
{
    public static void Run()
    {
        Console.WriteLine("=== Decorator Pattern - Ejemplo Avanzado: Data Stream ===\n");

        // Stream simple
        Console.WriteLine("--- Stream simple ---");
        IDataStream stream1 = new FileDataStream();
        stream1.Write("Hola Mundo");
        stream1.Read();
        stream1.Close();

        // Stream con compresión
        Console.WriteLine("\n--- Stream con compresión ---");
        IDataStream stream2 = new CompressionDecorator(new FileDataStream());
        stream2.Write("Hola Mundo");
        stream2.Read();
        stream2.Close();

        // Stream con encriptación
        Console.WriteLine("\n--- Stream con encriptación ---");
        IDataStream stream3 = new EncryptionDecorator(new FileDataStream());
        stream3.Write("Secreto");
        stream3.Read();
        stream3.Close();

        // Stream con compresión, encriptación y logging
        Console.WriteLine("\n--- Stream con compresión, encriptación y logging ---");
        IDataStream stream4 = new LoggingDecorator(
            new CompressionDecorator(
                new EncryptionDecorator(
                    new FileDataStream()
                )
            )
        );
        stream4.Write("Información sensible");
        stream4.Read();
        stream4.Close();

        // Stream con otra combinación
        Console.WriteLine("\n--- Stream con encriptación, compresión y logging ---");
        IDataStream stream5 = new LoggingDecorator(
            new EncryptionDecorator(
                new CompressionDecorator(
                    new FileDataStream()
                )
            )
        );
        stream5.Write("Datos importantes");
        stream5.Read();
        stream5.Close();

        Console.WriteLine("\n Decorator permite aplicar múltiples comportamientos en cualquier orden");
    }
}