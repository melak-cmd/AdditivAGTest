using ConsoleApp.Models;
using ConsoleApp.Purchasing;

namespace ConsoleApp.ShopChain
{
    public class PurchasingHandler : AbstractHandler
    {
        private readonly PurchasingStrategy _context;

        public PurchasingHandler()
        {
            _context = PurchasingStrategy.Instance();
        }

        public override object Handle(object request)
        {
            Guard.NotNull(() => request, request);
            return Handle((dynamic) request);
        }

        private object Handle(Basket basket)
        {
            _context.SetStrategy(new PurchasingStrategyDefault());
            var list = _context.Calcul(basket);
            return base.Handle(list);
        }
    }
}