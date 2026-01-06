using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    private IMessageRepository? _messageRepository;
    private IMemberRepository? _memberRepository;
    private ILikesRepository? _likesRepository;

    public IMessageRepository MessageRepository => _messageRepository
        ??= new MessageRepository(context);
    public IMemberRepository MemberRepository => _memberRepository
        ??= new MemberRepository(context);
    public ILikesRepository LikesRepository => _likesRepository
        ??= new LikesRepository(context);

    public async Task<bool> Complete()
    {
        try
        {
            return await context.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception("An error occurred while saving changes to the database.", ex);
        }
    }

    public bool HasChanges()
    {
        return context.ChangeTracker.HasChanges();
    }
}