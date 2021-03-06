using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("api/authorCollections")]
    public class AuthorCollectionController :ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;

        public IMapper _mapper { get; }

        public AuthorCollectionController(ICourseLibraryRepository courseLibraryRepository,
                IMapper mapper)
        {

            _courseLibraryRepository = courseLibraryRepository ?? throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


      

        
        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorCollection(
                 IEnumerable<AuthorForCreationDto> authorCollection)
        {
            var authorEntities = _mapper.Map<IEnumerable<Entities.Author>>(authorCollection);
            foreach (var author in authorEntities)

            {
                _courseLibraryRepository.AddAuthor(author);

            }
            _courseLibraryRepository.Save();
            return Ok();
        }

    }
}
