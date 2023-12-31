﻿using Health_Clinic_api.Domains;
using Health_Clinic_api.Interfaces;
using Health_Clinic_api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Health_Clinic_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Cadastra uma nova consulta
        /// </summary>
        /// <param name="novaConsulta">Objeto do tipo Consulta</param>
        /// <returns>Statuscode</returns>
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);
                return Ok("Consulta criada com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Buscar uma consulta por id
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Objeto do tipo Consulta e statuscode</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Consulta consultaBuscada = _consultaRepository.BuscarPorId(id);
                if (consultaBuscada != null)
                    return Ok(consultaBuscada);
                return NotFound("Nenhum médico existente!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Remove/Deleta um objeto do tipo Consulta pelo id
        /// </summary>
        /// <param name="id">Id da consulta</param>
        /// <returns>Statuscode</returns>
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                Consulta consulta = _consultaRepository.RemoverPorId(id);
                if (consulta != null)
                    return Ok("Consulta deletada com sucesso!");
                return NotFound("Consulta não encontrada!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Altera uma consulta por meio do id
        /// </summary>
        /// <param name="id">Id da Consulta buscada</param>
        /// <param name="prontuario">Prontuário a ser inserido</param>
        /// <returns>Statuscode</returns>
        [HttpPut]
        public IActionResult Put(Guid id, string prontuario)
        {
            try
            {
                Consulta consultaAtualizada = _consultaRepository.AtualizarProntuario(id, prontuario);
                if (consultaAtualizada != null)
                    return Ok("Consulta alterada com sucesso!");
                return NotFound();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }




        /// <summary>
        /// Adiciona um comentário à Consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta</param>
        /// <param name="novoComentario">Objeto do tipo Comentario</param>
        /// <returns>Statuscode</returns>
        [HttpPut("AdicionarComentario")]
        public IActionResult PostComment(Guid idConsulta, Comentario novoComentario)
        {
            try
            {
                _consultaRepository.AdicionarComentario(idConsulta, novoComentario);
                return Ok("Comentário inserido com sucesso!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Remove um comentário inserido na consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta</param>
        /// <returns>Statuscode</returns>
        [HttpDelete("DeletarComentario")]
        public IActionResult DeleteComment(Guid idConsulta)
        {
            try
            {
                Comentario comentarioBuscado = _consultaRepository.RemoverComentario(idConsulta);
                return comentarioBuscado != null ? Ok("Comentário excluido com sucesso!") : NotFound("Nenhum comentário encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Altera um comentário existente na consulta
        /// </summary>
        /// <param name="idConsulta">Id da consulta</param>
        /// <param name="comentario">Objeto do tipo Comentario</param>
        /// <returns></returns>
        [HttpPut("EditarComentario")]
        public IActionResult PutComment(Guid idConsulta, Comentario comentario)
        {
            try
            {
                Comentario comentarioBuscado = _consultaRepository.EditarComentario(idConsulta, comentario);
                return comentarioBuscado != null ? Ok("Comentário alterado com sucesso!") : NotFound("Nenhum comentário encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}