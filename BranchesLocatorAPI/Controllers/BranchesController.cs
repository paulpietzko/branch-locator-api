using BranchesLocatorAPI.Data;
using BranchesLocatorAPI.Models;
using BranchesLocatorAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BranchesLocatorAPI.Controllers
{
    // localhost:xxxx/api/branches
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BranchesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllBranches()
        {
            return Ok(dbContext.Branches.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBranchById(Guid id)
        {
            var branch = dbContext.Branches.Find(id);

            if(branch is null)
                return NotFound();

            return Ok(branch);
        }

        [HttpPost]
        public IActionResult AddBranch(AddBranchDto addBranchDto)
        {
            var branchEntity = new Branch()
            {
                Email = addBranchDto.Email,
                Name = addBranchDto.Name,
                Canton = addBranchDto.Canton,
                Location = addBranchDto.Location,
                PostCode = addBranchDto.PostCode,
                Phone = addBranchDto.Phone,
                OpeningHours = addBranchDto.OpeningHours,
                Website = addBranchDto.Website,
                Lat = addBranchDto.Lat,
                Lng = addBranchDto.Lng,
                ImageUrl = addBranchDto.ImageUrl
            };

            dbContext.Branches.Add(branchEntity);
            dbContext.SaveChanges();

            return Ok(branchEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateBranch(Guid id, UpdateBranchDto UpdateBranchDto)
        {
            var branch = dbContext.Branches.Find(id);

            if (branch is null)
                return NotFound();

            branch.Name = UpdateBranchDto.Name;
            branch.PostCode = UpdateBranchDto.PostCode;
            branch.Location = UpdateBranchDto.Location;
            branch.Email = UpdateBranchDto.Email;
            branch.Canton = UpdateBranchDto.Canton;
            branch.Website = UpdateBranchDto.Name;
            branch.OpeningHours = UpdateBranchDto.OpeningHours;
            branch.Phone = UpdateBranchDto.Phone;
            branch.Website = UpdateBranchDto.Website;
            branch.Lat = UpdateBranchDto.Lat;
            branch.Lng = UpdateBranchDto.Lng;
            branch.ImageUrl = UpdateBranchDto.ImageUrl;

            dbContext.SaveChanges();

            return Ok(branch);
        }
        
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteBranch(Guid id)
        {
            var branch = dbContext.Branches.Find(id);

            if (branch is null)
                return NotFound();

            dbContext.Branches.Remove(branch);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
