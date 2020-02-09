using AppServices.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiContracts.DTO;

namespace AppServices.Services
{
    public class GroupService : IGroupService
    {
        protected readonly IGroupRepository _groupRepository;
        protected readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GroupDto> Create(GroupDto entity)
        {
            Group result = null;
            try
            {
                result = _mapper.Map<Group>(entity);
            }
            catch (Exception ex)
            {
                string mess = ex.Message.ToString();
                throw new Exception();
            }
            Group std = await _groupRepository.Create(result);
            if (std != null)
                return entity;
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            Group std = await _groupRepository.Get(id);
            if (std != null)
            {
                await _groupRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<GroupDto> Get(int id)
        {
            Group group = await _groupRepository.Get(id);
            GroupDto groupDto = _mapper.Map<GroupDto>(group);
            return groupDto;
        }

        public GroupDto Get(string groupName)
        {
            Group group = _groupRepository.Get(groupName);
            GroupDto groupDto = _mapper.Map<GroupDto>(group);
            return groupDto;
        }

        public IList<GroupDto> GetAll(int departmentId)
        {
            IList<Group> Groups = _groupRepository.GetAll(departmentId).ToList();
            IList<GroupDto> GroupsDto = _mapper.Map<IList<GroupDto>>(Groups);
            return GroupsDto;
        }

        public IList<GroupDto> GetAll(string departmentName)
        {
            IList<Group> Groups = _groupRepository.GetAll(departmentName).ToList();
            IList<GroupDto> GroupsDto = _mapper.Map<IList<GroupDto>>(Groups);
            return GroupsDto;
        }

        public IList<GroupDto> GetAll()
        {
            IList<Group> Groups = _groupRepository.GetAll().ToList();
            IList<GroupDto> GroupsDto = _mapper.Map<IList<GroupDto>>(Groups);
            return GroupsDto;
        }

        public async Task<GroupDto> Update(GroupDto entity)
        {
            var result = _mapper.Map<Group>(entity);
            await _groupRepository.Update(result);
            return entity;
        }
    }
}
