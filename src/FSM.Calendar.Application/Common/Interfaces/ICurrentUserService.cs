namespace FSM.Calendar.Application.Common.Interfaces;

public interface ICurrentUserService
{
    string UserId { get; }

    bool IsAuthenticated { get; }
}