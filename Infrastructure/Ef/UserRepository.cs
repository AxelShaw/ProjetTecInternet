using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using Infrastructure.Ef.DbEntities;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class UserRepository : IUserRepository
{
    private MovieContextProvider _contextProvider;

    public UserRepository(MovieContextProvider contextProvider)
    {
        _contextProvider = contextProvider;
    }

    public UserRepository()
    {
        throw new NotImplementedException();
    }

    //get all user
    public IEnumerable<DbUser> FetchAll()
    {
        using var context = _contextProvider.NewContext();
        return context.User.ToList();
    }

    //get a user by id
    public DbUser FetchById(int id)
    {
        using var context = _contextProvider.NewContext();
        var user = context.User.FirstOrDefault(g => g.IdUser == id);

        if (user == null)
            throw new KeyNotFoundException($"Movie with id {id} has not been found");

        return user;
    }

    //create a new user
    public DbUser Create(string lastName, string firstName, string mail, string nickName, string password,
        string role, byte[] profilePic)
    {
        using var context = _contextProvider.NewContext();
    
        var allUser = context.User.ToList().Where(g => g.mail.ToLower().Contains(mail.ToLower()));

        if (allUser.ToList().Count > 0)
        {
            return null;
        }
        
        //set encryption method with sha256
        SHA256 sha256Hash = SHA256.Create();
        //get a hash
        var passwordHash = HashedPassword.GetHash(sha256Hash, password);
        var user = new DbUser
        {
            last_name = lastName,
            first_name = firstName,
            mail = mail,
            nickname = nickName,
            password = passwordHash.ToString(),
            role = "user",
            profil_picture = profilePic,
        };
        context.User.Add(user);
        context.SaveChanges();
        return user;
    }

    // delete a user by id
    public bool Delete(int id)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.User.Remove(new DbUser { IdUser = id });
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    //update a user 
    public bool Update(DbUser user)
    {
        using var context = _contextProvider.NewContext();
        try
        {
            context.User.Update(user);
            
            
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }
    
    //get 5 users by name 
    public IEnumerable<DbUser> FetchByName(string nickName)
    {
        using var context = _contextProvider.NewContext();
        var user = context.User.ToList().Where(g => g.nickname.ToLower().Contains(nickName.ToLower()));
        
        user = user.Take(5);

        if (user == null)
            throw new KeyNotFoundException($"User with name {nickName} has not been found");

        return user;
    }
}