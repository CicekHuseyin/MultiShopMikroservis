using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationService cargoOperationService, IMapper mapper)
        {
            _cargoOperationService = cargoOperationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = _mapper.Map<CargoOperation>(createCargoOperationDto);
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo Operasyonu Başarıyla Oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Operasyonu Başarıyla Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = _mapper.Map<CargoOperation>(updateCargoOperationDto);
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo Operasyonu Başarıyla Güncellendi.");
        }
    }
}
