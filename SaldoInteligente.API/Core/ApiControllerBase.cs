using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SaldoInteligente.Domain.Core.Notifications;
using SaldoInteligente.Domain.Responses;
using System.Text;

namespace SaldoInteligente.API.Core
{
    [Route("api/v1/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private readonly DomainNotificationHandler notifications;

        protected ApiControllerBase(INotificationHandler<DomainNotification> notifications)
        {
            this.notifications = (DomainNotificationHandler)notifications;
        }

        protected IEnumerable<DomainNotification> Notifications => notifications.GetNotifications();

        private bool IsValidOperation()
        {
            return !notifications.HasNotifications();
        }

        protected IActionResult CreateResponse<T>(Func<T> function)
        {
            try
            {
                var data = function.Invoke();

                return Response(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    notifications = ex.InnerException
                });
            }
        }

        private new IActionResult Response(object data = null)
        {
            if (IsValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data
                });
            }

            //var arr = notifications.GetNotifications().ToArray();

            return BadRequest(new
            {
                success = false,
                notifications = notifications.GetNotifications()
            });
        }

        protected IActionResult CreateResponse(Action action)
        {
            try
            {
                action.Invoke();

                return Response();
            }
            catch (Exception ex)
            {
                var arrNote = notifications.GetNotifications().ToArray();
                StringBuilder errorsString = new StringBuilder();

                for (int i = 0; i < arrNote.Length; i++)
                {
                    var item = arrNote[i];
                    errorsString.AppendLine(item.Value.ToString());
                }

                return StatusCode(500, new
                {
                    success = false,
                    notifications = notifications.GetNotifications()
                });
            }
        }        
    }
}