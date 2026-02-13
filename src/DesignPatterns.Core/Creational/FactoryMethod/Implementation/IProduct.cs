using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Core.Creational.FactoryMethod.Implementation
{
    /// <summary>
    /// Interfaz que define el contrato para los productos
    /// </summary>
    public interface IProduct
    {
        string GetProductType();
        void Operation();
    }
}
