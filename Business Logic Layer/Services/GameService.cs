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
    public class GameService : IGameService
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

        public async Task AddGenreToGameAsync(int gameId, int genreId)
        {
            var game = await unitOfWork.GameRepository.GetByIdAsync(gameId);
            var genre = await unitOfWork.GenreRepository.GetByIdAsync(genreId);

            game.Genres.Add(genre);
        }

        public async Task AddPEGIRatingAsync(PEGIRatingModel pegiModel)
        {
            await unitOfWork.PEGIRatingRepository.AddAsync(mapper.Map<PEGIRating>(pegiModel));
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.GameRepository.DeleteByIdAsync(modelId);
        }

        public async Task<IEnumerable<GameModel>> GetAllAsync()
        {
            var games = await unitOfWork.GameRepository.GetAllAsync();
            return mapper.Map<IEnumerable<GameModel>>(games);
        }

        public async Task<IEnumerable<PEGIRatingModel>> GetAllPEGIRatingAsync()
        {
            var ratings = await unitOfWork.PEGIRatingRepository.GetAllAsync();
            return mapper.Map<IEnumerable<PEGIRatingModel>>(ratings);
        }
        public async Task<IEnumerable<GenreModel>> GetAllGenresAsync()
        {
            var genres = await unitOfWork.GenreRepository.GetAllAsync();
            return mapper.Map<IEnumerable<GenreModel>>(genres);
        }
        public Task<IEnumerable<GameModel>> GetByFilterAsync(SearchModel searchModel)
        {
            throw new NotImplementedException();
        }

        public async Task<GameModel> GetByIdAsync(int id)
        {
            var game = await unitOfWork.GameRepository.GetByIdAsync(id);
            return mapper.Map<GameModel>(game);
        }

        public async Task<PEGIRatingModel> GetPEGIRatingByIdAsync(int pegiId)
        {
            var rating = await unitOfWork.PEGIRatingRepository.GetByIdAsync(pegiId);
            return mapper.Map<PEGIRatingModel>(rating);
        }

        public async Task RemoveGenreAsync(int genreId)
        {
            await unitOfWork.GenreRepository.DeleteByIdAsync(genreId);
        }

        public async Task RemovePEGIRatingAsync(int pegiId)
        {
            await unitOfWork.PEGIRatingRepository.DeleteByIdAsync(pegiId);
        }

        public async Task UpdateAsync(GameModel model)
        {
            await Task.Run(() => unitOfWork.GameRepository.Update(mapper.Map<Game>(model)));
        }

        public async Task UpdateGenreAsync(GenreModel genreModel)
        {
            await Task.Run(() => unitOfWork.GenreRepository.Update(mapper.Map<Genre>(genreModel)));
        }

        public async Task UpdatePEGIRatingAsync(PEGIRatingModel pegiModel)
        {
            await Task.Run(() => unitOfWork.PEGIRatingRepository.Update(mapper.Map<PEGIRating>(pegiModel)));
        }
    }
}
