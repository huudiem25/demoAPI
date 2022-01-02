﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.EntityData;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaisController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TheLoaisController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsLoai = _context.Loais.ToList();
                return Ok(dsLoai);

            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            //return Ok(dsLoai);
            if(loai != null)
            {
                return Ok(loai);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TheLoai = model.TheLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            }
            catch
            {
                return BadRequest();
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            //return Ok(dsLoai);
            if (loai != null)
            {
                loai.TheLoai = model.TheLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            //return Ok(dsLoai);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK) ;
            }
            else
            {
                return NotFound();
            }
        }
    }
}
