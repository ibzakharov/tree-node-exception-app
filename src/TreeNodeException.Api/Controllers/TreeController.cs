﻿using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreeNodeException.Api.Dtos;
using TreeNodeException.Api.Repositories;

namespace TreeNodeException.Api.Controllers;

[Route("api/tree")]
[ApiController]
public class TreeController : ControllerBase
{
    private readonly ITreeRepository _treeRepository;
    private readonly IMapper _mapper;

    public TreeController(ITreeRepository treeRepository,
        IMapper mapper)
    {
        _treeRepository = treeRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<NodeDto>> GetOrCreateTree([FromQuery, Required] string treeName)
    {
        var tree = await _treeRepository.GetTreeByNameAsync(treeName);

        if (tree == null)
        {
            tree = await _treeRepository.CreateTreeAsync(treeName);
        }

        tree = await _treeRepository.GetTreeChildrenByNameAsync(treeName);

        return Ok(_mapper.Map<NodeDto>(tree));
    }
}