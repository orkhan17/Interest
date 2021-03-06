using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Project.API.Data.IRepository;
using Project.API.Models;

namespace Project.API.Data.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;
        public PostRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<IEnumerable<Account>> GetAccounts()
        {
            var accounts = _context.Accounts.AsQueryable();
            var result = accounts.Where(a => a.Status==1).ToListAsync();
            return await result;
        }

        public async Task<IEnumerable<Music_type_account>> GetAccountsPreference(int id)
        {
            var pref = await _context.Music_type_accounts.Where(i => i.Account_Id == id).ToListAsync();
            return pref;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id && p.Status==1);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = _context.Posts.AsQueryable();
            var result = posts.Where(a => a.Status == 1).ToListAsync();
            return await result;
        }

        public async Task<IEnumerable<Post>> Get5Posts()
        {
            var posts = _context.Posts.AsQueryable();
            var result = posts.Where(a => a.Status == 1).OrderByDescending(d => d.Created_date).ToListAsync();
            return await result;
        }



        public async Task<IEnumerable<Visited_profile>> GetVisitedProfiles(int id)
        {
            var profiles =  _context.Visited_profiles.AsQueryable();
            var visited_profile = profiles.Where(p => p.AccountId == id).ToListAsync();
            return await visited_profile;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Account> GetAccount(int id)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id && a.Status == 1);
            return user;
        }

        public async Task<Post_Like> GetLike(int userid, int postid)
        {
            var like = await _context.Post_Likes.FirstOrDefaultAsync( l => l.AccountId==userid && l.Post_id==postid);
            return like;
        }

        public async Task<Follower> GetFollow(int userid, int followingid)
        {
            var follow = await _context.Followers.FirstOrDefaultAsync( l => l.AccountId==userid && l.Following_AccountId==followingid);
            return follow;
        }

        public async Task<IEnumerable<Follower>> Getfollowing(int id)
        {
            var followings =  _context.Followers.AsQueryable();
            var result = followings.Where(a => a.AccountId == id).ToListAsync();
            return await result;
        }
    }
}