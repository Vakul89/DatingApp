using API.Entities;

namespace API.Interfaces;

public interface IMemberRepository
{
    void UpdateMember(Member member);
    Task<IReadOnlyList<Member>> GetMembersAsync();
    Task<Member?> GetMemberByIdAsync(string id);
    Task<IReadOnlyList<Photo>> GetPhotosForMemberAsync(string memberId);
    Task<bool> SaveAllAsync();
}
