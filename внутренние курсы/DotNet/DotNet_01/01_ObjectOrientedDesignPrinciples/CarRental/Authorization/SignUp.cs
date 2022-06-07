namespace CarRental
{
    public class SignUp<T> where T : User
    {
        private IRecorder<T> _recorder;

        private IRecorder<User> _userRecorder;

        private IVerifier _verifier;

        public SignUp(IRecorder<T> recorder, IRecorder<User> userRecorder, IVerifier verifier)
        {
            _recorder = recorder;
            _verifier = verifier;
            _userRecorder = userRecorder;
        }

        public bool Register(T role)
        {
            if (_verifier.Check(role.Login, role.Password, out User user))
            {
                return false;
            }
            else
            {
                return _userRecorder.Add(new User(role.Login, role.Password, role.Role)) && _recorder.Add(role);
            }
        }
    }
}