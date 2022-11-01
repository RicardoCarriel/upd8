using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using upd8.MVC.ViewModels;
using upd8.Business.Interfaces;
using upd8.Business.Models;

namespace upd8.MVC.Controllers;

public class ClienteController : BaseController
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IClienteService _clienteService;
    private readonly IMapper _mapper;

    public ClienteController(IClienteRepository clienteRepository,
        IClienteService clienteService,
        IMapper mapper,
        INotificador notificador) : base(notificador)
    {
        _clienteRepository = clienteRepository;
        _clienteService = clienteService;
        _mapper = mapper;
    }

    [Route("lista-de-clientes")]
    public async Task<IActionResult> Index()
    {
        return View(_mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.ObterTodos()));
    }

    public async Task<IActionResult> Search(string Pesquisa = "")
    {
        var clienteViewModel = await ObterClientePorNome(Pesquisa);

        if (clienteViewModel == null) return NotFound();

        return View(clienteViewModel);
    }

    [Route("adicionar-cliente")]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [Route("adicionar-cliente")]
    [HttpPost]
    public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
    {
        if (!ModelState.IsValid) return View(clienteViewModel);

        var cliente = _mapper.Map<Cliente>(clienteViewModel);
        await _clienteService.Adicionar(cliente);

        if (!OperacaoValida()) return View(clienteViewModel);

        return RedirectToAction("Index");
    }

    [Route("editar-cliente/{id:guid}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var clienteViewModel = await ObterClientePorId(id);

        if (clienteViewModel == null) return NotFound();

        return View(clienteViewModel);
    }

    [Route("editar-cliente/{id:guid}")]
    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
    {
        if (id != clienteViewModel.Id) return NotFound();

        if (!ModelState.IsValid) return View(clienteViewModel);

        var cliente = _mapper.Map<Cliente>(clienteViewModel);
        await _clienteService.Atualizar(cliente);

        if (!OperacaoValida()) return View(await ObterClientePorId(id));

        return RedirectToAction("Index");
    }

    [Route("excluir-cliente/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var cliente = await ObterClientePorId(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }

    [Route("excluir-cliente/{id:guid}")]
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var cliente = await ObterClientePorId(id);

        if (cliente == null) return NotFound();

        await _clienteService.Remover(id);

        if (!OperacaoValida()) return View(cliente);

        return RedirectToAction("Index");
    }


    private async Task<ClienteViewModel> ObterClientePorId(Guid id)
    {
        return _mapper.Map<ClienteViewModel>(await _clienteRepository.ObterPorId(id));
    }

    private async Task<IEnumerable<ClienteViewModel>> ObterClientePorNome(string nome)
    {
        return _mapper.Map<IEnumerable<ClienteViewModel>>(await _clienteRepository.Buscar(c => c.Nome == nome));
    }
}
