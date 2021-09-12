using System;
using System.Threading.Tasks;
using RelationshipApi.Models.Dtos;
using RelationshipApi.Repositories.Interfaces;
using RelationshipApi.Services.Interfaces;

namespace RelationshipApi.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly ITokenRepository _tokenRepo;
        private readonly IMemberRepository _memberRepo;
        private readonly ICacheService _cacheService;

        public TokenService(ITokenRepository tokenRepo, IMemberRepository memberRepo, ICacheService cacheService)
        {
            _tokenRepo = tokenRepo;
            _memberRepo = memberRepo;
            _cacheService = cacheService;
        }

        public async Task<UserTokenDto> GetTokenByMemberId(Guid memberId)
        {
            if (await ValidateMemberId(memberId))
                throw new ArgumentNullException(nameof(memberId),
                    $" Can not find member by membershipId {memberId}.");
            
            var tokens = await _tokenRepo.GetTokensByMemberId(memberId);

            return new UserTokenDto
            {
                UserId = memberId,
                Tokens = tokens
            };
        }

        public async Task<TokenDto> GetTokenById(Guid id)
        {
            return await _tokenRepo.GetTokenById(id);
        }

        public async Task<TokenDto> UpdateToken(TokenDto token)
        {
            if (await ValidateMemberId(token.MemberId))
                throw new ArgumentNullException(nameof(token),
                    $" Can not find member by membershipId: {token.MemberId}, tokenId: {token.Id}.");

            if (await ValidateMemberId(token.IssuerId))
                throw new ArgumentNullException(nameof(token),
                    $" Can not find issuer member by membershipId: {token.IssuerId}, tokenId: {token.Id}.");

            return await _tokenRepo.UpdateToken(token);
        }

        public async Task<TokenDto> CreateToken(TokenDto token)
        {
            if (await ValidateMemberId(token.MemberId))
                throw new ArgumentNullException(nameof(token),
                    $" Can not find member by membershipId: {token.MemberId}, tokenId: {token.Id}.");

            if (await ValidateMemberId(token.IssuerId))
                throw new ArgumentNullException(nameof(token),
                    $" Can not find issuer member by membershipId: {token.IssuerId}, tokenId: {token.Id}.");

            return await _tokenRepo.CreateToken(token);
        }

        public async Task<bool> DeleteToken(Guid id)
        {
            if (await _tokenRepo.GetTokenById(id) == null)
                throw new ArgumentNullException(nameof(id),
                    $" Can not find token by id: {id}.");
            return await _tokenRepo.DeleteToken(id);
        }

        private async Task<bool> ValidateMemberId(Guid id)
        {
            var cachedValue = _cacheService.TryGetValue<bool>($"member_{id}");
            if (cachedValue)
            {
                // about structured logging msg vs basic logging msg, please refer to here
                // https://stackoverflow.com/questions/65874828/message-template-should-be-compile-time-constant/65938575#65938575
                // _logger.LogInformation("Product {ProductId} is reading from cache", productId);
                return true;
            }

            var result = await _memberRepo.GetMemberById(id) == null;
            _cacheService.SetCacheValue($"member_{id}", result);

            return result;
        }
    }
}