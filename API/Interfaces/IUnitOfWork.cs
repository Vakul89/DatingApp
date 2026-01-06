namespace API.Interfaces;

public interface IUnitOfWork
{
    IMessageRepository MessageRepository { get; }
    IMemberRepository MemberRepository { get; }
    ILikesRepository LikesRepository { get; }

    Task<bool> Complete();
    bool HasChanges();
}
