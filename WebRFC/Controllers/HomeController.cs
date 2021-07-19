using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRFC.Models;

namespace WebRFC.Controllers
{
    
    public class HomeController : Controller
    {
        BusRFC obj = new BusRFC();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BaseDatos()
        {
            try
            {
                using (G10BEntities db = new G10BEntities())
                {
                    List<UsuariosRFC> ls = db.UsuariosRFC.ToList();
                    UsuariosRFC repetido = new UsuariosRFC();                   
                    //ls = db.UsuariosRFC.SqlQuery("Select Id, Nombre,Paterno, Materno, RFC, FNacimiento, Row_Number() over(partition by  rfc order by rfc desc) as Repetidos from UsuariosRFC").ToList();
                    TempData["contar"] = " Existen "+ db.UsuariosRFC.Count() + " registros en la base de datos";
                   return View(ls.OrderBy(x=> x.Nombre));
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }
        public ActionResult IngresaDatos()
        {
            return  View();
        }
        [HttpPost]
        public ActionResult IngresaDatos(UsuariosRFC u)
        {
            try
            {
                
                obj.ValidarRFC(u);
                using (G10BEntities db = new G10BEntities())
                {
                    
                    string dd = u.FNacimiento.ToString("yyMMdd");
                    string rfc = obj.CrearRFC(u);
                    
                    bool evitar= Convert.ToBoolean( db.PalabrasExcentas.Where(x => x.Nombre.Contains(rfc)).Select(x=> 1).FirstOrDefault());
                    if (evitar == true)
                    {                        
                        string afrc = rfc.Substring(0,3) + 'X'+ dd;
                        u.RFC = afrc;
                    }
                    else
                    {
                        rfc += dd;
                        u.RFC = rfc;
                    }

                    db.UsuariosRFC.Add(u);

                    db.SaveChanges();
                    return View("RFC", u);
                }
                
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (G10BEntities db= new G10BEntities())
                {
                    UsuariosRFC us = db.UsuariosRFC.Where(x => x.Id == id).FirstOrDefault();
                    return View(us);
                }
            }
            catch (Exception ex)
            {

                TempData["error"]= ex.Message;
                return RedirectToAction("BaseDatos");
            }
            
        }
        [HttpPost]
        public ActionResult Delete(UsuariosRFC us)
        {
            try
            {
                using (G10BEntities db = new G10BEntities())
                {
                    UsuariosRFC borrar = db.UsuariosRFC.Find(us.Id);
                    db.UsuariosRFC.Remove(borrar);
                    db.SaveChanges();
                    return RedirectToAction("BaseDatos");
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View(us);
            }

        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (G10BEntities db = new G10BEntities())
                {
                    UsuariosRFC us = db.UsuariosRFC.Where(x => x.Id == id).FirstOrDefault();
                    return View(us);
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return RedirectToAction("BaseDatos");
            }

        }
        [HttpPost]
        public ActionResult Edit(UsuariosRFC us)
        {
            try
            {
                using (G10BEntities db = new G10BEntities())
                {
                    UsuariosRFC modificar = db.UsuariosRFC.Find(us.Id);
                    modificar.Nombre = us.Nombre;
                    modificar.Paterno = us.Paterno;
                    modificar.Materno = us.Materno;
                    modificar.FNacimiento = us.FNacimiento;


                    string dd = us.FNacimiento.ToString("yyMMdd");
                    string rfc = obj.CrearRFC(us);

                    bool evitar = Convert.ToBoolean(db.PalabrasExcentas.Where(x => x.Nombre.Contains(rfc)).Select(x => 1).FirstOrDefault());
                    if (evitar == true)
                    {
                        string afrc = rfc.Substring(0, 3) + 'X' + dd;
                        us.RFC = afrc;
                    }
                    else
                    {
                        rfc += dd;
                        us.RFC = rfc;
                    }

                    modificar.RFC = us.RFC;

                    db.SaveChanges();
                    return RedirectToAction("BaseDatos");
                }
            }
            catch (Exception ex)
            {

                TempData["error"] = ex.Message;
                return View(us);
            }
        }
        public ActionResult Buscar(string Buscar) 
        {
            try
            {
                using (G10BEntities db = new G10BEntities())
                {
                    List<UsuariosRFC> us = db.UsuariosRFC.Where(x => x.Nombre.Contains(Buscar) || x.Paterno.Contains(Buscar)|| x.Materno.Contains(Buscar)|| x.FNacimiento.ToString().Contains(Buscar) || x.RFC.Contains(Buscar)).ToList();
                    return View("BaseDatos", us);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("BaseDatos");
            }
        }
    }
}