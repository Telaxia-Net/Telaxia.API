using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class UserService:IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<UserResponse> SaveAsync(User user)
    {
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(user);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while saving the User: {e.Message}");
        }
    }

    public async Task<UserResponse> UpdateAsync(int id, User user)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Phone = user.Phone;
        existingUser.Mail = user.Mail;

        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the user: {e.Message}");
        }
    }
    public async Task<UserResponse> UpdateAsyncRating(int id, User category)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("Category not found.");

        existingUser.Rating = category.Rating;

        try
        {
            _userRepository.Update(existingUser);
            await _unitOfWork.CompleteAsync();
            
            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            return new UserResponse($"An error occurred while updating the User: {e.Message}");
        }
    }
    public async Task<UserResponse> DeleteAsync(int id)
    {
        var existingUser = await _userRepository.FindByIdAsync(id);

        if (existingUser == null)
            return new UserResponse("User not found.");

        try
        {
            _userRepository.Remove(existingUser);
            await _unitOfWork.CompleteAsync();

            return new UserResponse(existingUser);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new UserResponse($"An error occurred while deleting the User: {e.Message}");
        }
    }
}