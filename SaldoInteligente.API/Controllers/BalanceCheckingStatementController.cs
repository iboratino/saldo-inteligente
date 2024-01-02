using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaldoInteligente.API.Core;
using SaldoInteligente.API.Utils;
using SaldoInteligente.Domain.Contracts.Services;
using SaldoInteligente.Domain.Core.Notifications;
using SaldoInteligente.Domain.Responses.BalanceCheckingStatementDTOs;

namespace SaldoInteligente.API.Controllers
{
    public class BalanceCheckingStatementController : ApiControllerBase
    {
        private readonly IBalanceCheckingStatementService statementService;

        public BalanceCheckingStatementController(INotificationHandler<DomainNotification> notifications, IBalanceCheckingStatementService balanceCheckingStatementService) : base(notifications)
        {
            this.statementService = balanceCheckingStatementService;
        }

        [HttpPost("AddLoose")]
        public IActionResult AddLooseEntry([FromBody] AddLooseEntryDTO statement)
        {
            if (ModelState.IsValid)
            {
                return CreateResponse(() => statementService.AddLooseEntry(statement));
            }
            else
            {
                return BadRequest(ModelStateUtils.CreateValidationErrorResponse(ModelState));
            }
        }

        [HttpPost("AddNotLoose")]
        public IActionResult AddNotLooseEntry([FromBody] AddNotLooseEntryDTO statement)
        {
            if (ModelState.IsValid)
            {
                return CreateResponse(() => statementService.AddNotLooseEntry(statement));
            }
            else
            {
                return BadRequest(ModelStateUtils.CreateValidationErrorResponse(ModelState));
            }
        }

        [HttpPut("Change")]
        public IActionResult Change([FromBody] ChangeDTO statement)
        {
            if (ModelState.IsValid)
            {
                return CreateResponse(() => statementService.Change(statement));
            }
            else
            {
                return BadRequest(ModelStateUtils.CreateValidationErrorResponse(ModelState));
            }
        }

        [HttpPut("Cancel/{Id}")]
        public IActionResult Cancel(int Id)
        {
            return CreateResponse(() => statementService.CancelStatement(Id));
        }

        [HttpPatch("Find")]
        public IActionResult Find([FromBody] FindRangeDateDTO find)
        {
            return CreateResponse(() => statementService.FindStatements(find));
        }
    }
}