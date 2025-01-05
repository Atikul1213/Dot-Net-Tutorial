namespace FirstCoreMVCWebApplication.SOLID.SRP
{
    public class Membership
    {
        private readonly DataUtitlity _dataUtility;
        private readonly EmailSender _emailSender;
        private readonly EncryptionUtility _encryptionUtility;

        public Membership(DataUtitlity dataUtility, EmailSender emailSender, EncryptionUtility encryptionUtility)
        {
            _dataUtility = dataUtility;
            _emailSender = emailSender;
            _encryptionUtility = encryptionUtility;
        }
        public void CreateAccount(string userName, string password, string email)
        {
            if (!_dataUtility.CheckDuplicateUserName(userName))
            {
                var encPass = _encryptionUtility.ExcryptPassword(password);
                if (_dataUtility.SaveAccount(userName, password, email))
                {
                    _emailSender.SendNewAccountEmail(email);
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
