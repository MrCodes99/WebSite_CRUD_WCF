using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Hacer la referencia al WCF (ServicioNegocios)
using WebSite_Semana11_Lunes.ServicioNegocios;

namespace WebSite_Semana11_Lunes.Controllers
{
    public class NegociosController : Controller
    {
        // Instancia del Servicio de tipo Client
        ServicioContratoClient servicio = new ServicioContratoClient();
        public ActionResult Index()
        {
            //Retornar el listado de Clientes
            return View(servicio.Clientes());
        }

        public ActionResult ClientesxPais(string pais = "")
        {
            ViewBag.pais = new SelectList(servicio.Paises(), "idpais", "nombrepais");
            
            //Retornar el listado de Clientes
            return View(servicio.ClientesxPais(pais));
        }

        public ActionResult Create()
        {
            ViewBag.pais = new SelectList(servicio.Paises(), "idpais", "nombrepais");

            return View(new cliente());
        }

        [HttpPost]
        public ActionResult Create(cliente reg)
        {
            ViewBag.pais = new SelectList(servicio.Paises(), "idpais", "nombrepais", reg.idpais);

            ViewBag.mensaje = servicio.Agregar(reg);

            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            { 
            return View(servicio.Clientes().Where(x=> x.idcliente == id).FirstOrDefault());
            }
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var reg = servicio.Clientes().Where(x => x.idcliente == id).FirstOrDefault();

            ViewBag.pais = new SelectList(servicio.Paises(), "idpais", "nombrepais", reg.idpais);

            return View(reg);
        }

        [HttpPost]
        public ActionResult Edit(cliente reg)
        {
            ViewBag.pais = new SelectList(servicio.Paises(), "idpais", "nombrepais", reg.idpais);

            ViewBag.mensaje = servicio.Actualizar(reg);

            return View(reg);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
                return RedirectToAction("Index");

            // ALMACENO EL REGISTRO POR SU id
            var reg = servicio.Clientes().Where(x => x.idcliente == id).FirstOrDefault();

            // EJECUTO
            ViewBag.mensaje = servicio.Eliminar(reg);

            // ENVIAR LA VISTA
            return RedirectToAction("Index");
        }

    }
}