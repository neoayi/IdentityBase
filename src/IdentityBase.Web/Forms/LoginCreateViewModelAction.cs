

namespace IdentityBase.Web.Forms
{
    using System.Threading.Tasks;
    using IdentityBase.Forms;

    public class LoginCreateViewModelAction : ILoginCreateViewModelAction
    {
        public int Step => 0;

        public async Task Execute(CreateViewModelContext context)
        {
            context.FormElements.Add(new FormElement
            {
                Name = "Email",
                ViewName = "FormElements/Email"
            });

            context.FormElements.Add(new FormElement
            {
                Name = "Password",
                ViewName = "FormElements/Password"
            });

            context.FormElements.Add(new FormElement
            {
                Name = "RememberMe",
                ViewName = "FormElements/RememberMe"
            });

            context.FormElements.Add(new FormElement
            {
                Name = "Submit",
                ViewName = "FormElements/Submit"
            });
        }
    }
}
