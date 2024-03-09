using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    /// <summary>
    /// Istället för att använda en abstrakt klass som vi gjorde i föregående projekt så använder vi oss av ett interface för att skapa en gemensam grund för samtliga klasser som representerar användare.
    /// Främst används detta för att möjliggöra funktionalitet/logik i logincontrollen då beroende på vad för typ av användare som loggar in så ska olika saker hända.
    /// Se logincontroller för implementation.
    /// </summary>
    public interface IUser
    {
         string name { get; set; }
         string password { get; set; }
    }
}
