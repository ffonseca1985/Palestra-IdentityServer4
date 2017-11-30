namespace ISMeetup.Repositories
{
    public class UserRepository
    {
        MeetupContext _meetupContext;

        public UserRepository()
        {
            _meetupContext = new MeetupContext();
        }
    }
}
