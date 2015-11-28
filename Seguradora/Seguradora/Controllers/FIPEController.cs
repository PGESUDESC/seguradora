using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Seguradora.Models;

namespace Seguradora.Controllers
{
    public class FipeController : Controller
    {
        //
        // GET: /Fipe/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Importacao()
        {
            MarcaService marcaService = new MarcaService();
            ModeloService modeloService = new ModeloService();
            AnoModeloService anoModeloService = new AnoModeloService();
            VeiculoService veiculoService = new VeiculoService();
            int tipoVeiculo = 1; //Carros
            string url = "https://fipe-parallelum.rhcloud.com/api/v1/carros/marcas";
            string json = string.Empty;
            using (var w = new WebClient())
            {
                try
                {
                    json = w.DownloadString(url);
                }
                catch (Exception) { }
            }

            if (!String.IsNullOrWhiteSpace(json))
            {
                List<Seguradora.JSONFIpe.Marca> marcas = JsonConvert.DeserializeObject<List<Seguradora.JSONFIpe.Marca>>(json);
                foreach (var marcaFipe in marcas)
                {
                    Marca marca = new Marca();
                    marca.Codigo = marcaFipe.codigo.ToString();
                    marca.Descricao = marcaFipe.nome;
                    marca.TipoVeiculo = tipoVeiculo;

                    if (!marcaService.Existe(marcaFipe.codigo.ToString()))
                        marcaService.Create(marca);
                    else
                        marca = marcaService.GetByCodigo(marcaFipe.codigo.ToString());

                    string urlModelo = string.Format("{0}/{1}/{2}", url, marcaFipe.codigo, "modelos");
                    json = new WebClient().DownloadString(urlModelo);
                    Seguradora.JSONFIpe.ModeloAno modeloAno = JsonConvert.DeserializeObject<Seguradora.JSONFIpe.ModeloAno>(json);

                    foreach (var modeloFipe in modeloAno.modelos)
                    {
                        Modelo modelo = new Modelo();
                        modelo.Codigo = modeloFipe.codigo.ToString();
                        modelo.Descricao = modeloFipe.nome;
                        modelo.Marca = marca.ID;
                        modelo.TipoVeiculo = tipoVeiculo;

                        if (!modeloService.Existe(modeloFipe.codigo.ToString()))
                            modeloService.Create(modelo);
                        else
                            modelo = modeloService.GetByCodigo(modeloFipe.codigo.ToString());
                        
                        string urlAnos = string.Format("{0}/{1}/{2}", urlModelo, modeloFipe.codigo, "anos");
                        json = new WebClient().DownloadString(urlAnos);
                        List<Seguradora.JSONFIpe.Ano> anos = JsonConvert.DeserializeObject<List<Seguradora.JSONFIpe.Ano>>(json);
                        foreach (var anoFipe in anos)
                        {
                            AnoModelo anoModelo = new AnoModelo();
                            anoModelo.Codigo = anoFipe.codigo.ToString();
                            anoModelo.Descricao = anoFipe.nome;
                            anoModelo.Marca = marca.ID;
                            anoModelo.Modelo = modelo.ID;
                            anoModelo.TipoVeiculo = tipoVeiculo;

                            if (!anoModeloService.Existe(anoFipe.codigo.ToString()))
                                anoModeloService.Create(anoModelo);
                            else
                                anoModelo = anoModeloService.GetByCodigo(anoFipe.codigo.ToString());
                            
                            string urlVeiculo = string.Format("{0}/{1}", urlAnos, anoFipe.codigo);
                            try
                            {
                                json = new WebClient().DownloadString(urlVeiculo);
                                Seguradora.JSONFIpe.Veiculo veiculoFipe = JsonConvert.DeserializeObject<Seguradora.JSONFIpe.Veiculo>(json);

                                Veiculo veiculo = new Veiculo();
                                veiculo.Valor = Convert.ToDecimal(veiculoFipe.Valor.Replace("R$", "").Trim());
                                veiculo.Combustivel = veiculoFipe.Combustivel;
                                veiculo.CodigoFipe = veiculoFipe.CodigoFipe;
                                veiculo.MesReferencia = veiculoFipe.MesReferencia;
                                veiculo.TipoVeiculo = veiculoFipe.TipoVeiculo;
                                veiculo.SiglaCombustivel = veiculoFipe.SiglaCombustivel;
                                veiculo.Marca = marca.ID;
                                veiculo.Modelo = modelo.ID;
                                veiculo.AnoModelo = anoModelo.ID;

                                if (!veiculoService.Existe(veiculoFipe.CodigoFipe.ToString()))
                                    veiculoService.Create(veiculo);
                                else
                                    veiculo = veiculoService.GetByCodigoFIPE(veiculoFipe.CodigoFipe.ToString());
                            }catch{
                                //nao conseguiu encontrar o veiculo...
                            }
                        }
                    }
                }
            }

            return View();
        }
    }
}