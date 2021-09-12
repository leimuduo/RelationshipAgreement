using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Models.Entities;
using RelationshipApi.Repositories.Interfaces;

namespace RelationshipApi.Repositories.Implementation
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MemberRepository> _logger;
        private readonly IMapper _mapper;

        public MemberRepository(ApplicationDbContext context, ILogger<MemberRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberById(Guid id)
        {
            var result = await _context.Members.FirstOrDefaultAsync(m => m.UserId == id);
            return _mapper.Map<Member, MemberDto>(result);
        }

        public async Task<MemberDto> CreateMember(MemberDto newMember)
        {
            var entity = _mapper.Map<MemberDto, Member>(newMember);
            var result = await _context.Members.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Member, MemberDto>(result.Entity);
        }

        /// <summary>
        /// TODO: Review whether we still need this method.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task<MemberDto> UpdateMember(MemberDto member)
        {
            var entity = _mapper.Map<MemberDto, Member>(member);
            var result = _context.Members.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<Member, MemberDto>(result.Entity);
        }

        public async Task<bool> DeleteMember(Guid id)
        {
            var entity = await _context.Members.FirstOrDefaultAsync(m => m.UserId == id);
            _context.Members.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}