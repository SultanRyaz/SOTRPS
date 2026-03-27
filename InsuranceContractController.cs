using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceContractController : ControllerBase
    {
        private static List<InsuranceContract> _insuranceContracts = new List<InsuranceContract>
        {
            new InsuranceContract
            {
                Id = 1,
                InsurerIndentity = "INS001",
                InsurantIdentity = "4512 345678",
                ObjectIdentity = "VIN1234567890",
                InsuredAmount = 2500000.00m,
                Date = new DateOnly(2024, 1, 15)
            },
            new InsuranceContract
            {
                Id = 2,
                InsurerIndentity = "INS001",
                InsurantIdentity = "5601 987654", 
                ObjectIdentity = "77:01:0001023:4567",
                InsuredAmount = 8500000.00m,
                Date = new DateOnly(2024, 2, 20)
            },
            new InsuranceContract
            {
                Id = 3,
                InsurerIndentity = "INS002",
                InsurantIdentity = "4512 345678", 
                ObjectIdentity = "VIN104507904",
                InsuredAmount = 800000.00m,
                Date = new DateOnly(2024, 3, 10)
            },
            new InsuranceContract
            {
                Id = 4,
                InsurerIndentity = "INS001",
                InsurantIdentity = "7823 456789",
                ObjectIdentity = "77:01:1023000:4567",
                InsuredAmount = 6000000.00m,
                Date = new DateOnly(2024, 3, 25)
            }
        };

        private static int _nextId = 5;

        // GET: api/InsuranceContracts - получение всех договоров
        [HttpGet]
        public ActionResult<IEnumerable<InsuranceContract>> GetInsuranceObjects()
        {
            return Ok(_insuranceContracts);
        }

        // GET: api/InsuranceContracts/id - получение договора по id
        [HttpGet("{id}")]
        public ActionResult<InsuranceContract> GetInsuranceObject(int id)
        {
            var obj = _insuranceContracts.FirstOrDefault(o => o.Id == id);
            if (obj == null)
                return NotFound($"Объект с ID {id} не найден");
            return Ok(obj);
        }

        // POST: api/InsuranceContracts - добавление нового договора
        [HttpPost]
        public ActionResult<InsuranceContract> CreateInsuranceObject(InsuranceContract obj)
        {
            obj.Id = _nextId++;
            _insuranceContracts.Add(obj);
            return CreatedAtAction(nameof(GetInsuranceObject), new { id = obj.Id }, obj);
        }

        // PUT: api/InsuranceContracts/id - обновление договора
        [HttpPut("{id}")]
        public IActionResult UpdateInsuranceObject(int id, InsuranceContract updatedObj)
        {
            var obj = _insuranceContracts.FirstOrDefault(o => o.Id == id);
            if (obj == null)
                return NotFound($"Объект с ID {id} не найден");

            obj.InsurerIndentity = updatedObj.InsurerIndentity;
            obj.InsurantIdentity = updatedObj.InsurantIdentity;
            obj.ObjectIdentity = updatedObj.ObjectIdentity;
            obj.InsuredAmount = updatedObj.InsuredAmount;
            obj.InsuredAmount = updatedObj.InsuredAmount;
            obj.Date = updatedObj.Date;

            return NoContent();
        }

        // DELETE: api/InsuranceContracts/id - удаление договора
        [HttpDelete("{id}")]
        public IActionResult DeleteInsuranceObject(int id)
        {
            var obj = _insuranceContracts.FirstOrDefault(o => o.Id == id);
            if (obj == null)
                return NotFound($"Объект с ID {id} не найден");

            _insuranceContracts.Remove(obj);
            return NoContent();
        }
    }
}