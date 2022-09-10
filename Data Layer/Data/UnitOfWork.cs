﻿using Data_Layer.Interfaces;
using Data_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreDbContext gameStoreDbContext;
        //private IGameRepository gameRepository;
        //private IGenreRespository genreRespository;
        //private IPEGIRatingRepository pegiRatingRepository;
        //private ICommentRepository commentRepository;
        //private IUserRepository userRepository;
        //private IPersonRepository personRepository;
        //private IRoleRepository roleRepository;
        //private ICartRepository cartRepository;
        //private IOrderRepository orderRepository;
        //private IOrderDetailsRepository orderDetailsRepository;
        public UnitOfWork(GameStoreDbContext gameStoreDbContext)
        {
            this.gameStoreDbContext = gameStoreDbContext;
            GameRepository = new GameRepository(gameStoreDbContext);
            GenreRepository = new GenreRepository(gameStoreDbContext);
            PEGIRatingRepository = new PEGIRatingRepository(gameStoreDbContext);
            CommentRepository = new CommentRepository(gameStoreDbContext);
            UserRepository = new UserRepository(gameStoreDbContext);
            PersonRepository = new PersonRepository(gameStoreDbContext);
            RoleRepository = new RoleRepository(gameStoreDbContext);
            CartRepository = new CartRepository(gameStoreDbContext);
            OrderRepository = new OrderRepository(gameStoreDbContext);
            OrderDetailsRepository = new OrderDetailsRepository(gameStoreDbContext);
        }
        public IGameRepository GameRepository { get; set; }

        public IGenreRepository GenreRepository { get; set; }

        public IPEGIRatingRepository PEGIRatingRepository { get; set; }

        public ICommentRepository CommentRepository { get; set; }

        public IUserRepository UserRepository { get; set; }

        public IPersonRepository PersonRepository { get; set; }

        public IRoleRepository RoleRepository { get; set; }

        public ICartRepository CartRepository { get; set; }

        public IOrderRepository OrderRepository { get; set; }

        public IOrderDetailsRepository OrderDetailsRepository { get; set; }
        public async Task SaveChangesAsync()
        {
            await gameStoreDbContext.SaveChangesAsync();
        }
    }
}
