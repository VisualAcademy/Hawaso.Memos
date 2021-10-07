using Hawaso.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Hawaso.Pages.Inquiries
{
    public partial class Details
    {
        #region Parameters
        [Parameter]
        public int Id { get; set; }
        #endregion

        #region Injectors
        [Inject]
        public IInquiryRepository RepositoryReference { get; set; }
        #endregion

        #region Properties
        public Inquiry Model { get; set; } = new Inquiry();

        public string Content { get; set; } = "";
        #endregion

        #region Lifecycle Methods
        /// <summary>
        /// 페이지 초기화 이벤트 처리기
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            Model = await RepositoryReference.GetByIdAsync(Id);
            Content = Dul.HtmlUtility.EncodeWithTabAndSpace(Model.Content);
        }
        #endregion
    }
}
