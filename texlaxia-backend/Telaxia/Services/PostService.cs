using texlaxia_backend.Shared.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Models;
using texlaxia_backend.Telaxia.Domain.Repositories;
using texlaxia_backend.Telaxia.Domain.Services;
using texlaxia_backend.Telaxia.Domain.Services.Communication;

namespace texlaxia_backend.Telaxia.Services;

public class PostService:IPostService
{
    private readonly IPostRepository _postRepository;

    private readonly IUnitOfWork _unitOfWork;

    public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
    {
        _postRepository = postRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await _postRepository.ListAsync();
    }

    public async Task<PostResponse> SaveAsync(Post category)
    {
        try
        {
            await _postRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return new PostResponse(category);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred while saving the Post: {e.Message}");
        }
    }

    public async Task<PostResponse> UpdateAsync(int id, Post post)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);

        if (existingPost == null)
            return new PostResponse("Category not found.");

        existingPost.Description = post.Description;
        existingPost.Title = post.Title;

        try
        {
            _postRepository.Update(existingPost);
            await _unitOfWork.CompleteAsync();
            
            return new PostResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred while updating the Post: {e.Message}");
        }
    }
    
    public async Task<PostResponse> UpdateAsyncLikes(int id, Post post)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);

        if (existingPost == null)
            return new PostResponse("Category not found.");

        existingPost.PostLike = post.PostLike;
        
        try
        {
            _postRepository.Update(existingPost);
            await _unitOfWork.CompleteAsync();
            
            return new PostResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostResponse($"An error occurred while updating the PostLike: {e.Message}");
        }
    }

    public async Task<PostResponse> DeleteAsync(int id)
    {
        var existingPost = await _postRepository.FindByIdAsync(id);

        if (existingPost == null)
            return new PostResponse("Post not found.");

        try
        {
            _postRepository.Remove(existingPost);
            await _unitOfWork.CompleteAsync();

            return new PostResponse(existingPost);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PostResponse($"An error occurred while deleting the Post: {e.Message}");
        }
    }
}