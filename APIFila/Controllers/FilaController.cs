using APIFila.Interface;
using APIFila.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIFila.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilaController : ControllerBase
    {
        private readonly IFila _fila;

        public FilaController(IFila fila)
        {
            _fila = fila;
        }

        [Route("AddItemFila")]
        [HttpPost]
        public string AddItemFila(IEnumerable< ItemFila> itemFila)
        {

            if (ModelState.IsValid)
            {
                string ValidaData = ValidaDatas(itemFila);
                if (ValidaData == string.Empty)
                {
                    if (_fila.AddItemFila(itemFila))
                    {
                        return "OK";
                    }
                    else
                    {
                        return "ocorreu um erro, tente novamente mais tarde";
                    }
                }
                else
                {
                    return ValidaData;
                }

            }
            else
            {
                return "Dados inválidos";
            }
            
        }
        [Route("GetItemFila")]
        [HttpGet]
        public Object GetItemFila()
        {
            ItemFila itemFila = new ItemFila();
            itemFila = _fila.GetItemFila();
            if (itemFila != null)
            {
                return itemFila;
            }
            itemFila = new ItemFila();
            return itemFila.MensagemRetorno = "Nenhum item na fila";
        }
        private string ValidaDatas(IEnumerable<ItemFila> itemFila)
        {
            DateTime temp;
            
            foreach (var item in itemFila)
            {
                if (!DateTime.TryParse(item.Data_Inicio, out temp) || !DateTime.TryParse(item.Data_Fim, out temp))
                {
                    return "Data início e/ou data fim inválido(s)";
                }
                DateTime dtInicio = Convert.ToDateTime(item.Data_Inicio);
                DateTime dtFim = Convert.ToDateTime(item.Data_Fim);

                if (dtInicio <= dtFim)
                {
                    return "";
                }
                else
                {
                    return "Data início maior que data fim";
                }
            }
            return "";
        }
    }
}
