using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using UnityExample.Contracts;
using UnityExample.Implementations;

namespace UnityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Registry

            // Declaramos un contenedor Unity
            var unityContainer = new UnityContainer();

            #region Simple Registry

            // Registramos IGame para que cuando se detecte la dependencia
            // proporcione una instancia de TrivialPursuit
            
            unityContainer.RegisterType<IGame, TrivialPursuit>();
            

            #endregion

            #region Property Injection

            // Inyectamos una propiedad cuando se resuelva la dependencia
            /*
            InjectionProperty injectionProperty = new InjectionProperty("Name", "Trivial Pursuit Genus Edition");
            unityContainer.RegisterType<IGame, TrivialPursuit>(injectionProperty);
            */
            
            #endregion

            #endregion

            #region Resolving

            #region Direct resolving

            // Hacemos que Unity resuelva la interfaz, proporcionando una instancia
            // de la clase TrivialPursuit
            var game = unityContainer.Resolve<IGame>();

            // Comprobamos que el funcionamiento es correcto
            game.addPlayer();
            game.addPlayer();
            Console.WriteLine(string.Format("{0} people playing to {1}", game.CurrentPlayers, game.Name));
            Console.ReadLine();

            #endregion

            #region Indirect resolving

            // Instanciamos un objeto de la clase Table a través de Unity
            var table = unityContainer.Resolve<Table>();

            table.AddPlayer();
            table.AddPlayer();
            table.Play();

            Console.WriteLine(table.GameStatus());
            Console.ReadLine();

            #endregion

            #region Parameter Injection

            // Sobrecargamos el parámetro del constructor de Table
            var table2 = unityContainer.Resolve<Table>(new ParameterOverride("game", new TicTacToe()));

            table2.AddPlayer();
            table2.AddPlayer();
            table2.Play();
            
            Console.WriteLine(table2.GameStatus());
            Console.ReadLine();

            #endregion

            #endregion

        }
    }
}
