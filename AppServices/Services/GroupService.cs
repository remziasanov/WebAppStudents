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

        public Task<GroupDto> Create(GroupDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDto> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GroupDto> Get(int id)
        {
            throw new NotImplementedException();
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

        public Task<GroupDto> Update(GroupDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
