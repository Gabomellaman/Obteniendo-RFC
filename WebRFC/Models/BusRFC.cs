using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebRFC.Models
{
    public class BusRFC
    {
        public void ValidarRFC(UsuariosRFC a)
        {
            
            if (a.Nombre.Trim()[0] =='.')
            {
               throw new Exception("Nombre o apellidos no pueden empezar con un '.'");
            }
            if (a.Paterno.Trim()[0] == '.')
            {
                throw new Exception("Nombre o apellidos no pueden empezar con un '.'");
            }
            if (a.Materno!=null)
            {
                if (a.Materno.Trim()[0] == '.')
                {
                throw new Exception("Nombre o apellidos no pueden empezar con un '.'");
                }
                
            }
        }
        public string CrearRFC(UsuariosRFC a)
        {
            string n = a.Nombre.Trim().ToUpper();
            string p = a.Paterno.Trim().ToUpper();
            
            string rfc = "";
            //filtro apellido paterno, empezando si es de un solo caracter
            if (p.Length == 1)
            {
                rfc += p + "X";
            }
            else
            {
                //Validando si es apellido compuesto
                string[] paterno = p.Split(' ');
                
                    //Validando si el apellido paterno  tiene mas de 2 letras en la primer parte en caso de ser compuesto
                    if (paterno[0].Length == 1)
                    {
                        rfc += paterno[0]+ "X";
                    }
                    else
                    {
                        //quitar primer caracter del  apellido paterno  y revisar si tiene despues del primer char vocales
                        rfc =ValidarVocales(paterno[0]);
                    }   
            }
            //----------------Empezamos con apellido materno----------------------------------//
            
            if (a.Materno == null)
            {
                rfc += "X";
            }
            else
            {
                string m = a.Materno.Trim().ToUpper();
                char sustituir = m[0];
                if (m[0] == 'Ñ')
                {
                    sustituir = 'X';
                }
                rfc +=sustituir;
            }
            //-------------Nombre---------------------------------
            //Validando si tiene dos nombres
            string[] nombre = n.Split(' ');
            
            //Validando si el segundo nombre empieza con Ñ
            if (nombre.Length >=2)
            {
                string segundoNombre = nombre[1];
                char sustituir = segundoNombre[0];
                if (segundoNombre[0] == 'Ñ')
                {
                    sustituir = 'X';
                }
                rfc += sustituir;
            }
            else
            {
                string unicoNombre = nombre[0];
                char sustituir = unicoNombre[0];
                if (unicoNombre[0] == 'Ñ')
                {
                    sustituir = 'X';
                }
                rfc += sustituir;
            }
            return rfc;
        }
        public string Cambiar(string a)
        {
            string cambiar = "";
            for (int i = 0; i < a.Length-1; i++)
            {
                cambiar += a[i];
            }
            cambiar += 'X';
            return cambiar;
        }
        public string ValidarVocales(string a)
        {
            char sustituir = a[0];
            if (a[0] == 'Ñ')
            {
                sustituir = 'X';
            }
            string componentesRFC = "";
            string quit = a.Substring(1, a.Length - 1);
            for (int i = 0; i < quit.Length; i++)
            {
                if (quit[i] == 'A')
                {
                    componentesRFC += sustituir + "A";
                    break;

                }
                if (quit[i] == 'E')
                {
                    componentesRFC += sustituir + "E";
                    break;
                }
                if (quit[i] == 'I')
                {
                    componentesRFC += sustituir + "I";
                    break;
                }
                if (quit[i] == 'O')
                {
                    componentesRFC += sustituir + "O";
                    break;
                }
                if (quit[i] == 'U')
                {
                    componentesRFC += sustituir + "U";
                    break;
                }
                if (i == quit.Length - 1)
                {
                    componentesRFC += sustituir + "X";
                }
            }
            return componentesRFC;
        }
    }
}