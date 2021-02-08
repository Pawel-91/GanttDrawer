using Microsoft.Extensions.DependencyInjection;
using MiniGantt.Interfaces;
using MiniGantt.Shapes.Interfaces;
using MiniGantt.WpfDrawers;
using System.Windows.Media;

namespace MiniGantt
{
    public static class ServicesConfiguration
    {
        public static ServiceCollection ConfigureServices(this ServiceCollection services)
        {
            services.AddScoped<IShapeDrawer<DrawingContext, IRectangleShape>, LegRectDrawer>();
            services.AddScoped<IShapeDrawer<DrawingContext, IArrowShape>, ArrowDrawer>();

            services.AddSingleton<MainWindow>();

            return services;
        }
    }
}
