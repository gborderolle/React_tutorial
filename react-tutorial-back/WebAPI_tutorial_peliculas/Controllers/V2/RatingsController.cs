using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebAPI_tutorial_peliculas.Context;
using WebAPI_tutorial_peliculas.DTOs;
using WebAPI_tutorial_peliculas.Models;
using WebAPI_tutorial_peliculas.Utilities;

namespace WebAPI_tutorial_peliculas.Controllers.V2
{
    [ApiController]
    [HasHeader("x-version", "2")] // Agregar header: "x-version": "1"
    [Route("api/ratings")]
    public class RatingsController : ControllerBase
    {
        protected readonly ILogger<RatingsController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ContextDB _contextDB;
        protected APIResponse _response;

        public RatingsController(ContextDB contextDB, ILogger<RatingsController> logger, UserManager<IdentityUser> userManager)
        {
            _response = new APIResponse();
            _logger = logger;
            _contextDB = contextDB;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<APIResponse>> Post([FromBody] RatingDTO ratingDTO)
        {
            try
            {
                var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;
                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        var userId = user.Id;
                        var currentRating = await _contextDB.Rating.FirstOrDefaultAsync(x => x.MovieId == ratingDTO.MovieId && x.UserId == userId);
                        if (currentRating == null)
                        {
                            var rating = new Rating
                            {
                                MovieId = ratingDTO.MovieId,
                                Score = ratingDTO.Score,
                                UserId = userId
                            };
                            _contextDB.Add(rating);
                        }
                        else
                        {
                            currentRating.Score = ratingDTO.Score;
                        }
                        await _contextDB.SaveChangesAsync();
                        _response.StatusCode = HttpStatusCode.OK;
                        _response.Result = NoContent();
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

    }
}