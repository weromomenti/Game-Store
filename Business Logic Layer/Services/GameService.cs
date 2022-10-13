using AutoMapper;
using Business_Logic_Layer.Infrastructure;
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
            await gameValidator.ValidateAndThrowAsync(model);
            await unitOfWork.GameRepository.AddAsync(mapper.Map<Game>(model));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task AddGenreAsync(GenreModel genreModel)
        {
            await genreValidator.ValidateAndThrowAsync(genreModel);
            await unitOfWork.GenreRepository.AddAsync(mapper.Map<Genre>(genreModel));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task AddGenreToGameAsync(int gameId, int genreId)
        {
            var game = await unitOfWork.GameRepository.GetByIdWithDetailsAsync(gameId);
            var genre = await unitOfWork.GenreRepository.GetByIdWithDetailsAsync(genreId);

            if (game.Genres.Contains(genre))
            {
                return;
            }

            game.Genres.Add(genre);
            await unitOfWork.SaveChangesAsync();
        }
        public async Task RemoveGenreFromGameAsync(int gameId, int genreId)
        {
            var game = await unitOfWork.GameRepository.GetByIdWithDetailsAsync(gameId);
            var genre = await unitOfWork.GenreRepository.GetByIdWithDetailsAsync(genreId);

            if (!game.Genres.Contains(genre))
            {
                return;
            }

            game.Genres.Remove(genre);await unitOfWork.SaveChangesAsync();
            await unitOfWork.SaveChangesAsync();
        }
        public async Task AddPEGIRatingAsync(PEGIRatingModel pegiModel)
        {
            await pEGIRatingValidator.ValidateAndThrowAsync(pegiModel);
            await unitOfWork.PEGIRatingRepository.AddAsync(mapper.Map<PEGIRating>(pegiModel));
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await unitOfWork.GameRepository.DeleteByIdAsync(modelId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GameModel>> GetAllAsync()
        {
            var games = await unitOfWork.GameRepository.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<GameModel>>(games);
        }

        public async Task<IEnumerable<PEGIRatingModel>> GetAllPEGIRatingAsync()
        {
            var ratings = await unitOfWork.PEGIRatingRepository.GetAllAsync();
            return mapper.Map<IEnumerable<PEGIRatingModel>>(ratings);
        }
        public async Task<IEnumerable<GenreModel>> GetAllGenresAsync()
        {
            var genres = await unitOfWork.GenreRepository.GetAllWithDetailsAsync();
            return mapper.Map<IEnumerable<GenreModel>>(genres);
        }
        public async Task<GenreModel> GetGenreByIdAsync(int id)
        {
            var genre = await unitOfWork.GenreRepository.GetByIdWithDetailsAsync(id);
            return mapper.Map<GenreModel>(genre);
        }
        public async Task<IEnumerable<GameModel>> GetByFilterAsync(SearchModel searchModel)
        {
            var games = await unitOfWork.GameRepository.GetAllWithDetailsAsync();

            if (searchModel?.Title != null && searchModel?.Title != string.Empty)
            {
                games = games.Where(g => g.Name.ToLower().Contains(searchModel.Title.ToLower()));
            }
            if (searchModel?.Genre != null && searchModel.Genre.Length > 0)
            {
                games = games.Where(g => g.Genres.Select(genre => genre.GenreName).Any(name => searchModel.Genre.Contains(name)));
            }
            return mapper.Map<IEnumerable<GameModel>>(games);
        }

        public async Task<GameModel> GetByIdAsync(int id)
        {
            var game = await unitOfWork.GameRepository.GetByIdWithDetailsAsync(id);
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
            await unitOfWork.SaveChangesAsync();
        }

        public async Task RemovePEGIRatingAsync(int pegiId)
        {
            await unitOfWork.PEGIRatingRepository.DeleteByIdAsync(pegiId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<GameModel> UpdateAsync(GameModel model)
        {
            await gameValidator.ValidateAndThrowAsync(model);
            await Task.Run(() => unitOfWork.GameRepository.Update(mapper.Map<Game>(model)));
            await unitOfWork.SaveChangesAsync();
            return model;
        }

        public async Task<GenreModel> UpdateGenreAsync(GenreModel genreModel)
        {
            await genreValidator.ValidateAndThrowAsync(genreModel);
            await Task.Run(() => unitOfWork.GenreRepository.Update(mapper.Map<Genre>(genreModel)));
            await unitOfWork.SaveChangesAsync();
            return genreModel;
        }

        public async Task<PEGIRatingModel> UpdatePEGIRatingAsync(PEGIRatingModel pegiModel)
        {
            await pEGIRatingValidator.ValidateAndThrowAsync(pegiModel);
            await Task.Run(() => unitOfWork.PEGIRatingRepository.Update(mapper.Map<PEGIRating>(pegiModel)));
            await unitOfWork.SaveChangesAsync();
            return pegiModel;
        }

        public async Task AddSubgenreAsync(int genreId, GenreModel subGenre)
        {
            var genre = await unitOfWork.GenreRepository.GetByIdWithDetailsAsync(genreId);
            genre.SubGenres.Add(mapper.Map<Genre>(subGenre));
            await unitOfWork.SaveChangesAsync();
        }
    }
}
