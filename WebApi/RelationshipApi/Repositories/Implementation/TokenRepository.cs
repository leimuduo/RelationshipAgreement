using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Models.Entities;
using RelationshipApi.Repositories.Interfaces;

namespace RelationshipApi.Repositories.Implementation
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TokenRepository> _logger;
        private readonly IMapper _mapper;

        public TokenRepository(ApplicationDbContext context, ILogger<TokenRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<TokenDto> GetTokenById(Guid id)
        {
            var entity = await _context.Tokens.FirstOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<Token, TokenDto>(entity);
        }

        public async Task<IEnumerable<TokenDto>> GetTokensByMemberId(Guid memberId)
        {
            var entities = await _context.Tokens.Where(t => t.MemberId == memberId).ToListAsync();
            return entities.Count == 0 ? null : _mapper.Map<List<Token>, List<TokenDto>>(entities);
        }

        public async Task<TokenDto> CreateToken(TokenDto token)
        {
            var result = await _context.AddAsync(_mapper.Map<TokenDto, Token>(token));
            await _context.SaveChangesAsync();
            return _mapper.Map<Token, TokenDto>(result.Entity);
        }

        public async Task<TokenDto> UpdateToken(TokenDto token)
        {
            var result = _context.Update(_mapper.Map<TokenDto, Token>(token));
            await _context.SaveChangesAsync();
            return _mapper.Map<Token, TokenDto>(result.Entity);
        }

        public async Task<bool> DeleteToken(Guid id)
        {
            var entity = await _context.Members.FirstOrDefaultAsync(m => m.UserId == id);
            _context.Members.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}