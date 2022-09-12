using AutoMapper;
using Business_Logic_Layer.Infrastructure.Validators;
using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Entities;
using Data_Layer.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    internal class GameService : IGameService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly GameValidator gameValidator;
        private readonly GenreValidator genreValidator;
        private readonly PEGIRatingValidator pEGIRatingValidator;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            gameValidator = new GameValidator();
            genreValidator = new GenreValidator();
            pEGIRatingValidator = new PEGIRatingValidator();
        }

        public async Task AddAsync(GameModel model)
        {
            try
            {
                await gameValidator.ValidateAsync(model);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Argument is Null");
            }
            await unitOfWork.GameRepository.AddAsync(mapper.Map<Game>(model));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task AddGenreAsync(GenreModel genreModel)
        {
            try
            {
                await genreValidator.ValidateAsync(genreModel);
            }
            catch (ArgumentNullException)
            {
                throw new Exception("Argument is Null");
            }
            await unitOfWork.GenreRepository.AddAsync(mapper.Map<Genre>(genreModel));
            await unitOfWork.SaveChangesAsync();
        }

        public Task AddGenreToGame(int gameId, int genreId)
        {
            var game = unitOfWork.GameRepository.GetByIdAsync(gameId);
            var genre = unitOfWork.GenreRepository.GetByIdAsync(genreId);


        }

        public Task AddPEGIRatingAsync(PEGIRatingModel pegiModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAllPEGIRatingAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameModel>> GetByFilterAsync(SearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public Task<GameModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetPEGIRatingByIdAsync(int pegiId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveGenreAsync(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task RemovePEGIRatingAsync(PEGIRatingModel pegiModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(GameModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGenreAsync(GenreModel genreModel)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePEGIRatingAsync(PEGIRatingModel pegiModel)
        {
            throw new NotImplementedException();
        }
    }
}
