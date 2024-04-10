using CS.BO.Entities;
using CS.BO.Repos;

namespace CS.TestProject
{
    public class UserRepositoryTests
    {
        private UserRepository _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new UserRepository();
        }

        [Test]
        public void Create_User_Success()
        {
            // Arrange
            var user = new User
            {
                GUID = Guid.NewGuid().ToString(),
                Name = "Kaking Choi",
                UserName = "kchoi",
                Email = "kaking.choi@intec.edu.do",
                Password = "1234",
                CreatedDate = DateTime.Now
            };

            // Act
            _userRepository.Create(user);


            // Assert
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual(1, _userRepository.GetAlls().Count());
        }

        [Test]
        public void Delete_ExistingUser_Success()
        {
            // Arrange
            var user = new User { Id = 1 };

            // Act
            _userRepository.Delete(user.Id);

            // Assert
            Assert.AreEqual(0, _userRepository.GetAlls().Count());
        }
    }
}