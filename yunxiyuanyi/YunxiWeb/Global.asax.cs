using Autofac;
using Autofac.Integration.Mvc;
using DataBase;
using IDataBase;
using ILogic;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace YunxiWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            #region 文章回复
            builder.RegisterType<ArticleReplyDal>().As<IArticleReplyDal>().InstancePerRequest();
            builder.RegisterType<ArticleReplyBll>().As<IArticleReplyBll>().InstancePerRequest();
            #endregion
            #region 文章信息
            builder.RegisterType<ArticleDal>().As<IArticleDal>().InstancePerRequest();
            builder.RegisterType<ArticleBll>().As<IArticleBll>().InstancePerRequest();
            #endregion
            #region 分类信息表
            builder.RegisterType<CategoryDal>().As<ICategoryDal>().InstancePerRequest();
            builder.RegisterType<CategoryBll>().As<ICategoryBll>().InstancePerRequest();
            #endregion
            #region 常用地址
            builder.RegisterType<CommonAddresDal>().As<ICommonAddresDal>().InstancePerRequest();
            builder.RegisterType<CommonAddresBll>().As<ICommonAddresBll>().InstancePerRequest();
            #endregion
            #region 投诉信息附件
            builder.RegisterType<ComplaintAttachmentDal>().As<IComplaintAttachmentDal>().InstancePerRequest();
            builder.RegisterType<ComplaintAttachmentBll>().As<IComplaintAttachmentBll>().InstancePerRequest();
            #endregion
            #region 投诉信息
            builder.RegisterType<ComplaintDal>().As<IComplaintDal>().InstancePerRequest();
            builder.RegisterType<ComplaintBll>().As<IComplaintBll>().InstancePerRequest();
            #endregion
            #region 买家信息
            builder.RegisterType<CustomerDal>().As<ICustomerDal>().InstancePerRequest();
            builder.RegisterType<CustomerBll>().As<ICustomerBll>().InstancePerRequest();
            #endregion
            #region 快递信息
            builder.RegisterType<ExpresseDal>().As<IExpresseDal>().InstancePerRequest();
            builder.RegisterType<ExpresseBll>().As<IExpresseBll>().InstancePerRequest();
            #endregion
            #region 收藏夹
            builder.RegisterType<FavoriteDal>().As<IFavoriteDal>().InstancePerRequest();
            builder.RegisterType<FavoriteBll>().As<IFavoriteBll>().InstancePerRequest();
            #endregion
            #region 抽奖行为记录
            builder.RegisterType<LotteryActiveDal>().As<ILotteryActiveDal>().InstancePerRequest();
            builder.RegisterType<LotteryActiveBll>().As<ILotteryActiveBll>().InstancePerRequest();
            #endregion
            #region 抽奖活动表
            builder.RegisterType<LotteryDrawDal>().As<ILotteryDrawDal>().InstancePerRequest();
            builder.RegisterType<LotteryDrawBll>().As<ILotteryDrawBll>().InstancePerRequest();
            #endregion
            #region 站内信
            builder.RegisterType<MessageDal>().As<IMessageDal>().InstancePerRequest();
            builder.RegisterType<MessageBll>().As<IMessageBll>().InstancePerRequest();
            #endregion
            #region 订单产品信息
            builder.RegisterType<OrderItemDal>().As<IOrderItemDal>().InstancePerRequest();
            builder.RegisterType<OrderItemBll>().As<IOrderItemBll>().InstancePerRequest();
            #endregion
            #region 订单信息
            builder.RegisterType<OrderDal>().As<IOrderDal>().InstancePerRequest();
            builder.RegisterType<OrderBll>().As<IOrderBll>().InstancePerRequest();
            #endregion
            #region 付款信息
            builder.RegisterType<PaymentDal>().As<IPaymentDal>().InstancePerRequest();
            builder.RegisterType<PaymentBll>().As<IPaymentBll>().InstancePerRequest();
            #endregion
            #region 奖品信息
            builder.RegisterType<PrizeDal>().As<IPrizeDal>().InstancePerRequest();
            builder.RegisterType<PrizeBll>().As<IPrizeBll>().InstancePerRequest();
            #endregion
            #region 评论图片
            builder.RegisterType<ProductCommentImageDal>().As<IProductCommentImageDal>().InstancePerRequest();
            builder.RegisterType<ProductCommentImageBll>().As<IProductCommentImageBll>().InstancePerRequest();
            #endregion
            #region 产品评价信息
            builder.RegisterType<ProductCommentDal>().As<IProductCommentDal>().InstancePerRequest();
            builder.RegisterType<ProductCommentBll>().As<IProductCommentBll>().InstancePerRequest();
            #endregion
            #region 商品图片信息
            builder.RegisterType<ProductImageDal>().As<IProductImageDal>().InstancePerRequest();
            builder.RegisterType<ProductImageBll>().As<IProductImageBll>().InstancePerRequest();
            #endregion
            #region 产品提问信息
            builder.RegisterType<ProductRequestionDal>().As<IProductRequestionDal>().InstancePerRequest();
            builder.RegisterType<ProductRequestionBll>().As<IProductRequestionBll>().InstancePerRequest();
            #endregion
            #region 商品信息
            builder.RegisterType<ProductDal>().As<IProductDal>().InstancePerRequest();
            builder.RegisterType<ProductBll>().As<IProductBll>().InstancePerRequest();
            #endregion
            #region 优惠活动
            builder.RegisterType<PromotionDal>().As<IPromotionDal>().InstancePerRequest();
            builder.RegisterType<PromotionBll>().As<IPromotionBll>().InstancePerRequest();
            #endregion
            #region 
            builder.RegisterType<SecurityQuestionDal>().As<ISecurityQuestionDal>().InstancePerRequest();
            builder.RegisterType<SecurityQuestionBll>().As<ISecurityQuestionBll>().InstancePerRequest();
            #endregion
            #region 店铺信息
            builder.RegisterType<ShopDal>().As<IShopDal>().InstancePerRequest();
            builder.RegisterType<ShopBll>().As<IShopBll>().InstancePerRequest();
            #endregion
            #region 卖家信息
            builder.RegisterType<SupplyDal>().As<ISupplyDal>().InstancePerRequest();
            builder.RegisterType<SupplyBll>().As<ISupplyBll>().InstancePerRequest();
            #endregion
            #region 用户积分记录
            builder.RegisterType<UserPointActiveDal>().As<IUserPointActiveDal>().InstancePerRequest();
            builder.RegisterType<UserPointActiveBll>().As<IUserPointActiveBll>().InstancePerRequest();
            #endregion
            #region 用户信息
            builder.RegisterType<UserDal>().As<IUserDal>().InstancePerRequest();
            builder.RegisterType<UserBll>().As<IUserBll>().InstancePerRequest();
            #endregion
            #region 邮箱/短信验证
            builder.RegisterType<VerificationDal>().As<IVerificationDal>().InstancePerRequest();
            builder.RegisterType<VerificationBll>().As<IVerificationBll>().InstancePerRequest();
            #endregion
            builder.RegisterFilterProvider();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
