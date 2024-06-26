﻿using MedicalAppAPI.Models.Domains;

namespace MedicalAppAPI.Repos.UserActions
{
    public interface IUserRepositoryActions
    {
        Task<User> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync(string? filterOn = null, string? filterQuery = null,
            int pageNumber = 1, int pageSize = 1000);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> UpdateUserAsync(Guid id, User user);
    }
}
