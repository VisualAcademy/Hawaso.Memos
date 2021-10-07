using Microsoft.EntityFrameworkCore;

namespace Hawaso.Models
{
    /// <summary>
    /// 메모앱(InquiryApp) 관련 의존성(종속성) 주입 관련 코드만 따로 모아서 관리 
    /// </summary>
    public static class InquiryAppStartupExtensions
    {
        public static void AddDependencyInjectionContainerForInquiryApp(this IServiceCollection services, string connectionString)
        {
            // InquiryAppDbContext.cs Inject: New DbContext Add
            services.AddDbContext<InquiryAppDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient);

            // IInquiryRepository.cs Inject: DI Container에 서비스(리포지토리) 등록 
            services.AddTransient<IInquiryRepository, InquiryRepository>();

            // 파일 업로드 및 다운로드 서비스(매니저) 등록
            services.AddTransient<IInquiryFileStorageManager, InquiryFileStorageManager>(); // Local Upload
        }
    }
}
